# LiveData for Unity

A lightweight, type-safe reactive data holder inspired by Android's LiveData — but made for Unity (C#).  
This lets you observe data changes safely, without needing manual event unsubscriptions.

✨ Key Features:
- Zero memory leaks: automatic cleanup of destroyed MonoBehaviours
- React to value changes with one line: `Observe(this, value => { ... })`
- Immediately receives the current value on subscribe
- Ideal for MVVM, clean architecture, UI binding, and reactive programming in Unity

🚀 Example:
```csharp
healthLiveData.Observe(this, hp => {
    Debug.Log("Current HP: " + hp);
});
