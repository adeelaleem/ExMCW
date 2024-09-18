# Securing PaaS

Fourth Coffee is an American coffeehouse chain that was founded in Seattle, Washington in 1970. It currently operates over 20,000 locations worldwide.

The CEO has established a mandate to revamp their loyalty program that starts with their platform. Other than tracking the serial number of the gift card, its balance and purchase history, Fourth Coffee does not have any direct way to associate the purchase history with the customer. They feel this is a big opportunity for them to address, and in doing so will enable them to launch their worldwide customer loyalty program.

In designing and implementing this solution, Fourth Coffee is very concerned about security. They had already launched a customer profile microsite alongside their primary website in Azure using Azure App Services, they host the website in a Web App and all logic is provided thru an API App. They would like to keep this core approach for the gift card website but extend it as appropriate with other Azure PaaS services.

A primary concern for Fourth Coffee is figuring out how to secure access to sensitive customer profile data, particularly to limit and control access by their developers. They have put together a ""solution security"" team who works in the office of the CISO (Chief Information Security Officer) that should be the only group allowed to view the secrets and keys used in production.

In addition to securing access to sensitive data, they would like to gain visibility into the security health of their solution.

## Target audience
- Application developers
- Cloud administrators
- Cloud architects
- Security architects

## Abstract

### Workshop

This workshop is designed to provide exposure to many of Microsoft Azure's Platform-as-a-Service (PaaS) security features. The goal is to show a secure end-to-end solution that addresses concerns around sensitive data, controlling access to sensitive stores of information, controlling access to production systems and enabling secure processes for developers.

In this workshop, you will learn how to build secure solutions end-to-end with Azure Platform-as-a-Service (PaaS) services, control access to PaaS service and how to manage secrets and keys used by PaaS services.

### Whiteboard Design Session

In this whiteboard design session, you will work with a group to design an end-to-end PaaS solution that combines many of Azure's security features, while protecting sensitive data from both internal and external users.

At the end of this whiteboard design session, you will be better able to design secure PaaS-based solutions that protect your systems and data from both internal and external threats.

### Hands-on Lab

In this hands-on-lab, you will design an end-to-end PaaS solution that combines many of Azure's security features, while protecting sensitive data from both internal and external users.

At the end of this hands-on lab, you will be better able to develop a secure solution that takes advantage of the security features provided by an App Service Environment (ASE). You will know how to use an Azure DevOps machine and Visual Studio to deploy to the ASE after creating an app service plan. You will know how to enable a Web Application Firewall to filter requests based on the OWASP 3.0 standard and see that those requests are in fact blocked. In addition, you will know how Azure Identity Access and Management (Azure IAM) works and how those access permissions are separate from policies that may live within the actual Azure resource (such as with Azure Key Vault). You will learn how to remove sensitive information from your various resources such as Azure Functions and Web Applications and place them in the Azure Key Vault for both deployment and runtime use. As a final step, you will learn how to perform queries against Log Analytics to populate a Power BI report based on your Web Application Firewall events.

## Azure services and related products
- Azure Key Vault
- AAD
- AAD B2C
- Functions
- Cosmos DB
- Azure Search
- Azure Security Center
- Log Analytics
- App Insights
- Azure Monitor
- App Service Environment
- App Gateway with WAF
- SQL Database
- Azure Storage

## Azure solutions

Security and Management

## Related references
- [MCW](https://github.com/Microsoft/MCW)

