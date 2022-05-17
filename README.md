## Containerization Options for Windows Communication Foundation (WCF) workloads

## Disclaimer

- This solution is provided as sample code and for educational purposes to demonstrate how WCF can be dockernised as is or modernised using .NET Core.
- LIMITATIONS: Deploying this solution requires opening up port 80 and 808 without encryption. We DO NOT recommend treating this solution as production code. Incoporating Transport Encryption using TLS is recommended.
- Input validation relies on WCF SOAP implementation. Extra validation is recommended from client-side.
- Success/Failure scenarios:
  - The client might fail to invoke the server if passing invalid values to the server side.

## Security

See [CONTRIBUTING](CONTRIBUTING.md#security-issue-notifications) for more information.

## License

This library is licensed under the MIT-0 License. See the LICENSE file.
