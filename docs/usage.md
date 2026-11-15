# Httping CLI guide

[Back to README](../README.md)

## Requests and results

Pass a full URL to select HTTPS explicitly:

```bash
httping --server https://example.com --count 4
```

A positional server is also supported:

```bash
httping www.bing.com
```

Each response reports the HTTP version, host/port, numeric status code, response size and elapsed time. The final summary contains the sent, received and lost request counts and minimum, maximum and average round-trip times. Timings and response sizes depend on the target.

An HTTP response such as 404 is still a received response; timeout and transport errors increase the lost count. The summary is a transport observation, not a check that the application returned a successful status code.

## Options

| Option | Meaning | Default |
| --- | --- | --- |
| `--server` | Domain, IP address or full URL; may also be positional | Required |
| `-n`, `--count` | Number of requests | `4` |
| `-w`, `--timeout` | Per-request timeout in milliseconds | `5000` |
| `-i`, `--interval` | Interval between request starts in milliseconds | `1000` |
| `-k`, `--insecure` | Disable TLS certificate validation | `false` |
| `-q`, `--quiet` | Suppress per-response output | `false` |
| `-f`, `--follow-redirect` | Follow redirects | `false` |
| `--no-proxy` | Bypass the system proxy | `false` |
| `-v`, `--verbose` | Detailed framework logging | `false` |
| `--version` | Show the tool version | — |
| `-?`, `-h`, `--help` | Show current help | — |

Read current help with `httping --help`. A URL without a scheme uses HTTP; use `https://` when HTTPS is required.

## Local checks

To probe an HTTP server that is already listening on port 8080:

```bash
httping --server http://127.0.0.1:8080 --count 1 --no-proxy
```

The tool makes a bounded request to that server; it does not start a server or change its configuration.
