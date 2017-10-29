import KsApi
import ReactiveSwift
import Result

public protocol MessageCellViewModelInputs {
  func configureWith(message: Message)
}

public protocol MessageCellViewModelOutputs {
  var avatarURL: Signal<URL?, NoError> { get }
  var name: Signal<String, NoError> { get }
  var timestamp: Signal<String, NoError> { get }
  var timestampAccessibilityLabel: Signal<String, NoError> { get }
  var body: Signal<String, NoError> { get }
}

public protocol MessageCellViewModelType {
  var inputs: MessageCellViewModelInputs { get }
  var outputs: MessageCellViewModelOutputs { get }
}

public final class MessageCellViewModel: MessageCellViewModelType, MessageCellViewModelInputs,
MessageCellViewModelOutputs {

  public init() {
    let message = self.messageProperty.signal.skipNil()

    self.avatarURL = message.map { URL.init(string: $0.sender.avatar.large ?? $0.sender.avatar.medium) }

    self.name = message.map { $0.sender.name }

    self.timestamp = message.map {
      Format.date(secondsInUTC: $0.createdAt, dateStyle: .short, timeStyle: .short)
    }

    self.timestampAccessibilityLabel = message.map {
      Format.date(secondsInUTC: $0.createdAt, dateStyle: .long, timeStyle: .short)
    }

    self.body = message.map { $0.body }
  }

  fileprivate let messageProperty = MutableProperty<Message?>(nil)
  public func configureWith(message: Message) {
    self.messageProperty.value = message
  }

  public let avatarURL: Signal<URL?, NoError>
  public let name: Signal<String, NoError>
  public let timestamp: Signal<String, NoError>
  public var timestampAccessibilityLabel: Signal<String, NoError>
  public let body: Signal<String, NoError>

  public var inputs: MessageCellViewModelInputs { return self }
  public var outputs: MessageCellViewModelOutputs { return self }
}
