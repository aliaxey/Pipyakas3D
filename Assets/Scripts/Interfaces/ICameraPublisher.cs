public interface ICameraPublisher {
    void SetSubscriber(ICameraSubscriber subscriber);
    void RemoveSubscriber(ICameraSubscriber subscriber);
}