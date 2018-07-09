# Overview
Generic logging utility.

# Usage
1. Extend the interfaces in the Platform Adapters folder for your specific use case.
2. Add your logger to the LogProxy class and use that if you require a static logger.

**Note**: It is recommended to ue or extend the ThreadedLogger as that will only enqueue logs on the calling thread and offload the actual logging process to a different thread.

# Log Levels
| Log Level | Usage |
| - | - |
| Verbose | Tracing information and debugging minutae. |
| Debug | Information to help with debugging. |
| Info | Information tracking the usage of the system. |
| Warning | Issues that should be addressed but do not break gameplay/user experience. |
| Error | Issues that break gameplay/user experience. |
| Fatal | Can be used instead of a direct method reference. |