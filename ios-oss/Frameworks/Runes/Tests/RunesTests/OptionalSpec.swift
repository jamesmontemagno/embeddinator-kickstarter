import XCTest
import SwiftCheck
import Mozart
import Runes

class OptionalSpec: XCTestCase {
  func testFunctor() {
    // fmap id = id
    property("identity law") <- forAll { (x: Int?) in
      let lhs = id <^> x
      let rhs = x

      return lhs == rhs
    }

    // fmap (f . g) = (fmap f) . (fmap g)
    property("function composition law") <- forAll { (o: OptionalOf<Int>, fa: ArrowOf<Int, Int>, fb: ArrowOf<Int, Int>) in
      let f = fa.getArrow
      let g = fb.getArrow
      let x = o.getOptional

      let lhs = f • g <^> x
      let rhs = (curry(<^>)(f) • curry(<^>)(g))(x)

      return lhs == rhs
    }
  }

  func testApplicative() {
    // pure id <*> v = v
    property("identity law") <- forAll { (x: Int?) in
      let lhs = pure(id) <*> x
      let rhs = x

      return lhs == rhs
    }

    // pure f <*> pure x = pure (f x)
    property("homomorphism law") <- forAll { (x: Int, fa: ArrowOf<Int, Int>) in
      let f = fa.getArrow

      let lhs: Int? = pure(f) <*> pure(x)
      let rhs: Int? = pure(f(x))

      return rhs == lhs
    }

    // f <*> pure x = pure ($ x) <*> f
    property("interchange law") <- forAll { (x: Int, fa: OptionalOf<ArrowOf<Int, Int>>) in
      let f = fa.getOptional?.getArrow

      let lhs = f <*> pure(x)
      let rhs = pure({ $0(x) }) <*> f

      return lhs == rhs
    }

    // u *> v = pure (const id) <*> u <*> v
    property("interchange law - right sequence") <- forAll { (ou: OptionalOf<Int>, ov: OptionalOf<Int>) in
      let u = ou.getOptional
      let v = ov.getOptional

      let lhs = u *> v
      let rhs = pure(curry(const)(id)) <*> u <*> v

      return lhs == rhs
    }

    // u <* v = pure const <*> u <*> v
    property("interchange law - left sequence") <- forAll { (ou: OptionalOf<Int>, ov: OptionalOf<Int>) in
      let u = ou.getOptional
      let v = ov.getOptional

      let lhs = u <* v
      let rhs = pure(curry(const)) <*> u <*> v

      return lhs == rhs
    }

    // f <*> (g <*> x) = pure (.) <*> f <*> g <*> x
    property("composition law") <- forAll { (o: OptionalOf<Int>, fa: OptionalOf<ArrowOf<Int, Int>>, fb: OptionalOf<ArrowOf<Int, Int>>) in
      let x = o.getOptional
      let f = fa.getOptional?.getArrow
      let g = fb.getOptional?.getArrow

      let lhs = f <*> (g <*> x)
      let rhs = pure(curry(•)) <*> f <*> g <*> x

      return lhs == rhs
    }
  }

  func testAlternative() {
    property("alternative operator - left empty") <- forAll { (x: Int) in
      let lhs: Int? = empty() <|> pure(x)
      let rhs: Int? = pure(x)

      return lhs == rhs
    }

    property("alternative operator - right empty") <- forAll { (x: Int) in
      let lhs: Int? = pure(x) <|> empty()
      let rhs: Int? = pure(x)

      return lhs == rhs
    }

    property("alternative operator - neither empty") <- forAll { (x: Int, y: Int) in
      let lhs: Int? = pure(x) <|> pure(y)
      let rhs: Int? = pure(x)

      return lhs == rhs
    }
  }

  func testMonad() {
    // return x >>= f = f x
    property("left identity law") <- forAll { (x: Int, fa: ArrowOf<Int, Int>) in
      let f: (Int) -> Int? = pure • fa.getArrow

      let lhs = pure(x) >>- f
      let rhs = f(x)

      return lhs == rhs
    }

    // m >>= return = m
    property("right identity law") <- forAll { (o: OptionalOf<Int>) in
      let x = o.getOptional

      let lhs = x >>- pure
      let rhs = x

      return lhs == rhs
    }

    // (m >>= f) >>= g = m >>= (\x -> f x >>= g)
    property("associativity law") <- forAll { (o: OptionalOf<Int>, fa: ArrowOf<Int, Int>, fb: ArrowOf<Int, Int>) in
      let m = o.getOptional
      let f: (Int) -> Int? = pure • fa.getArrow
      let g: (Int) -> Int? = pure • fb.getArrow

      let lhs = (m >>- f) >>- g
      let rhs = m >>- { x in f(x) >>- g }

      return lhs == rhs
    }

    // (f >=> g) >=> h = f >=> (g >=> h)
    property("left-to-right Kleisli composition of monads") <- forAll { (x: Int, fa: ArrowOf<Int, Int>, fb: ArrowOf<Int, Int>, fc: ArrowOf<Int, Int>) in
      let f: (Int) -> Int? = pure • fa.getArrow
      let g: (Int) -> Int? = pure • fb.getArrow
      let h: (Int) -> Int? = pure • fc.getArrow

      let lhs = (f >-> g) >-> h
      let rhs = f >-> (g >-> h)

      return lhs(x) == rhs(x)
    }

    // (f <=< g) <=< h = f <=< (g <=< h)
    property("right-to-left Kleisli composition of monads") <- forAll { (x: Int, fa: ArrowOf<Int, Int>, fb: ArrowOf<Int, Int>, fc: ArrowOf<Int, Int>) in
      let f: (Int) -> Int? = pure • fa.getArrow
      let g: (Int) -> Int? = pure • fb.getArrow
      let h: (Int) -> Int? = pure • fc.getArrow

      let lhs = (f <-< g) <-< h
      let rhs = f <-< (g <-< h)

      return lhs(x) == rhs(x)
    }
  }
}
