# Console, EventLog & DebugView 
This repository is a proof of concept for producing logs to Console, Windows Event Log Viewer and DebugView, while using the same interface. Serilog was used to carry out suchs operations. It was injected as usual and configured from appsettings.

Importat: In case of creating custom log name in Windows Event Log, you should run it with Administrative priviledges, either Visual Studio running the app or the app itself.