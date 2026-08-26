# pagdi

## Malware Source Code

**pagdi** is a malware research sample intended for controlled analysis, reverse engineering, and defensive-security testing.

> **WARNING:** This repository contains potentially malicious source code. Do not compile or execute it outside an isolated laboratory environment.

## Purpose

This project is designed for:

* Malware analysis and reverse engineering
* Static and dynamic analysis
* Detection-engine development
* IOC extraction
* Sandbox testing
* Security education and research

## Analysis Environment

Use a dedicated, isolated malware-analysis environment.

Recommended controls:

* Disposable virtual machine
* Network isolation or controlled simulation
* No personal credentials or sensitive files
* VM snapshots
* Process and filesystem monitoring
* Network traffic capture
* Host-based detection tooling

## Analysis

Researchers can examine the source to identify:

* Execution flow
* Suspicious behaviors
* Indicators of compromise
* File and process activity
* Network-related behavior
* Potential detection opportunities

## Safety

Never execute the sample on a production computer or a system without explicit authorization.

If the repository contains a live payload, treat it as **untrusted and potentially destructive software**.

## Disclaimer

`pagdi` is provided solely for authorized security research and education. The maintainers do not authorize unauthorized access, disruption, data theft, persistence, credential theft, or deployment against third-party systems.

Use this material only in environments where you have permission to conduct security testing.

## License

See the repository's license for applicable terms.
