![](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")


<div class="MCWHeader1">
Securing PaaS
</div>

<div class="MCWHeader2">
Hands-on lab unguided
</div>

<div class="MCWHeader3">
December 2018
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only, and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third-party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are the property of their respective owners.

**Contents**
<!-- TOC -->

- [Securing PaaS hands-on lab unguided](#securing-paas-hands-on-lab-unguided)
    - [Abstract and learning objectives](#abstract-and-learning-objectives)
    - [Overview](#overview)
    - [Solution architecture](#solution-architecture)
    - [Requirements](#requirements)
    - [Exercise 1: Creating and securing Azure Active Directory accounts](#exercise-1-creating-and-securing-azure-active-directory-accounts)
        - [Task 1: Create Azure Active Directory groups](#task-1-create-azure-active-directory-groups)
            - [Tasks to Complete](#tasks-to-complete)
            - [Exit Criteria](#exit-criteria)
        - [Task 2: Create Azure Active Directory accounts](#task-2-create-azure-active-directory-accounts)
            - [Tasks to Complete](#tasks-to-complete-1)
            - [Exit Criteria](#exit-criteria-1)
        - [Task 3: Enable Azure Identity Protection features](#task-3-enable-azure-identity-protection-features)
            - [Tasks to Complete](#tasks-to-complete-2)
            - [Exit Criteria](#exit-criteria-2)
    - [Exercise 2: Securing Azure Key Vault with Azure IAM](#exercise-2-securing-azure-key-vault-with-azure-iam)
        - [Task 1: Create a new Azure Key Vault](#task-1-create-a-new-azure-key-vault)
            - [Tasks to Complete](#tasks-to-complete-3)
            - [Exit Criteria](#exit-criteria-3)
        - [Task 2: Assign IAM based Azure Key Vault permissions](#task-2-assign-iam-based-azure-key-vault-permissions)
            - [Tasks to Complete](#tasks-to-complete-4)
            - [Exit Criteria](#exit-criteria-4)
        - [Task 3: Assign access policy based Azure Key Vault permissions](#task-3-assign-access-policy-based-azure-key-vault-permissions)
            - [Tasks to Complete](#tasks-to-complete-5)
            - [Exit Criteria](#exit-criteria-5)
        - [Task 4: Verify Azure Key Vault permissions](#task-4-verify-azure-key-vault-permissions)
            - [Tasks to Complete](#tasks-to-complete-6)
            - [Exit Criteria](#exit-criteria-6)
    - [Exercise 3: Azure deployments using Azure Key Vault](#exercise-3-azure-deployments-using-azure-key-vault)
        - [Task 1: Create new secrets](#task-1-create-new-secrets)
            - [Tasks to Complete](#tasks-to-complete-7)
            - [Exit Criteria](#exit-criteria-7)
        - [Task 2: Deploy an ARM Template using Azure Key Vault resources](#task-2-deploy-an-arm-template-using-azure-key-vault-resources)
            - [Tasks to Complete](#tasks-to-complete-8)
            - [Exit Criteria](#exit-criteria-8)
    - [Exercise 4: Securing the web application and database](#exercise-4-securing-the-web-application-and-database)
        - [Task 1: Setup the database](#task-1-setup-the-database)
            - [Tasks to Complete](#tasks-to-complete-9)
            - [Exit Criteria](#exit-criteria-9)
        - [Task 2: Test the web application solution](#task-2-test-the-web-application-solution)
            - [Tasks to Complete](#tasks-to-complete-10)
            - [Exit Criteria](#exit-criteria-10)
        - [Task 3: Utilize data masking](#task-3-utilize-data-masking)
            - [Tasks to Complete](#tasks-to-complete-11)
            - [Exit Criteria](#exit-criteria-11)
        - [Task 4: Utilize column encryption with Azure Key Vault](#task-4-utilize-column-encryption-with-azure-key-vault)
            - [Tasks to Complete](#tasks-to-complete-12)
            - [Exit Criteria](#exit-criteria-12)
        - [Task 5: Enable SQL Azure Auditing & Threat Detection](#task-5-enable-sql-azure-auditing--threat-detection)
            - [Tasks to Complete](#tasks-to-complete-13)
            - [Exit Criteria](#exit-criteria-13)
        - [Task 6: Ensure SQL Azure Transparent Data Encryption (TDE) is enabled](#task-6-ensure-sql-azure-transparent-data-encryption-tde-is-enabled)
            - [Tasks to Complete](#tasks-to-complete-14)
            - [Exit Criteria](#exit-criteria-14)
    - [Exercise 5: Migrating web.config settings to azure key vault](#exercise-5-migrating-webconfig-settings-to-azure-key-vault)
        - [Task 1: Create an Azure Key Vault secret](#task-1-create-an-azure-key-vault-secret)
            - [Tasks to Complete](#tasks-to-complete-15)
            - [Exit Criteria](#exit-criteria-15)
        - [Task 2: Create an Azure Active Directory application](#task-2-create-an-azure-active-directory-application)
            - [Tasks to Complete](#tasks-to-complete-16)
            - [Exit Criteria](#exit-criteria-16)
        - [Task 3: Assign the new Application Azure Key Vault Permissions](#task-3-assign-the-new-application-azure-key-vault-permissions)
            - [Tasks to Complete](#tasks-to-complete-17)
            - [Exit Criteria](#exit-criteria-17)
        - [Task 4: Install NuGet packages](#task-4-install-nuget-packages)
            - [Tasks to Complete](#tasks-to-complete-18)
            - [Exit Criteria](#exit-criteria-18)
        - [Task 5: Test the solution](#task-5-test-the-solution)
            - [Tasks to Complete](#tasks-to-complete-19)
            - [Exit Criteria](#exit-criteria-19)
    - [Exercise 6: Securing PaaS web applications with App Service Environment and Web Application Firewall](#exercise-6-securing-paas-web-applications-with-app-service-environment-and-web-application-firewall)
        - [Task 1: Deploy web application to app service environment](#task-1-deploy-web-application-to-app-service-environment)
            - [Tasks to Complete](#tasks-to-complete-20)
            - [Exit Criteria](#exit-criteria-20)
        - [Task 2: Configure the Web Application Firewall](#task-2-configure-the-web-application-firewall)
            - [Tasks to Complete](#tasks-to-complete-21)
            - [Exit Criteria](#exit-criteria-21)
        - [Task 3: Enable Application Gateway logging](#task-3-enable-application-gateway-logging)
            - [Tasks to Complete](#tasks-to-complete-22)
            - [Exit Criteria](#exit-criteria-22)
        - [Task 4: Attack a ASE Web Application with Detection Only](#task-4-attack-a-ase-web-application-with-detection-only)
            - [Tasks to Complete](#tasks-to-complete-23)
            - [Exit Criteria](#exit-criteria-23)
        - [Task 5: Enable Web Application Firewall Prevention](#task-5-enable-web-application-firewall-prevention)
            - [Tasks to Complete](#tasks-to-complete-24)
            - [Exit Criteria](#exit-criteria-24)
        - [Task 6: Reattack an ASE Web Application with Prevention enabled](#task-6-reattack-an-ase-web-application-with-prevention-enabled)
            - [Tasks to Complete](#tasks-to-complete-25)
            - [Exit Criteria](#exit-criteria-25)
    - [Exercise 7: Securing Azure Functions with Managed Service Identities](#exercise-7-securing-azure-functions-with-managed-service-identities)
        - [Task 1: Create an Azure Function](#task-1-create-an-azure-function)
            - [Tasks to Complete](#tasks-to-complete-26)
            - [Exit Criteria](#exit-criteria-26)
        - [Task 2: Create a Managed Service Identity](#task-2-create-a-managed-service-identity)
            - [Tasks to Complete](#tasks-to-complete-27)
            - [Exit Criteria](#exit-criteria-27)
        - [Task 3: Assign Managed Service Identity Azure Key Vault Permissions](#task-3-assign-managed-service-identity-azure-key-vault-permissions)
            - [Tasks to Complete](#tasks-to-complete-28)
            - [Exit Criteria](#exit-criteria-28)
        - [Task 4: Test your Azure Function](#task-4-test-your-azure-function)
            - [Tasks to Complete](#tasks-to-complete-29)
            - [Exit Criteria](#exit-criteria-29)
    - [Exercise 8: Creating PaaS Audit and Compliance Power BI Reports](#exercise-8-creating-paas-audit-and-compliance-power-bi-reports)
        - [Task 1: Export a Power Query formula from Log Analytics](#task-1-export-a-power-query-formula-from-log-analytics)
            - [Tasks to Complete](#tasks-to-complete-30)
            - [Exit Criteria](#exit-criteria-30)
    - [After the hands-on lab](#after-the-hands-on-lab)
        - [Task 1: Delete resource group](#task-1-delete-resource-group)
        - [Task 2: Delete Azure AD objects](#task-2-delete-azure-ad-objects)
        - [Task 3: Delete lab environment (optional)](#task-3-delete-lab-environment-optional)

<!-- /TOC -->


# Securing PaaS hands-on lab unguided 

## Abstract and learning objectives 

In this hands-on-lab, you will design an end-to-end PaaS solution that combines many of Azure's security features, while protecting sensitive data from both internal and external users.

At the end of this hands-on lab, you will be better able to develop a secure solution that takes advantage of the security features provided by an App Service Environment (ASE). You will know how to use an Azure DevOps machine and Visual Studio to deploy to the ASE after creating an app service plan. You will know how to enable a Web Application Firewall to filter requests based on the OWASP 3.0 standard and see that those requests are in fact blocked. In addition, you will know how Azure Identity Access and Management (Azure IAM) works and how those access permissions are separate from policies that may live within the actual Azure resource (such as with Azure Key Vault). You will learn how to remove sensitive information from your various resources such as Azure Functions and Web Applications and place them in the Azure Key Vault for both deployment and runtime use. As a final step, you will learn how to perform queries against Log Analytics to populate a Power BI report based on your Web Application Firewall events.
## Overview

In this hands-on lab, attendees will implement several of PaaS security features of Azure to help ensure a secure application environment.

## Solution architecture

Below is a diagram of the solution architecture you will build in this lab. Please study this carefully, so you understand the whole of the solution as you are working on the various components.

![The High-level architecture diagram has two sides: Public internet, and Azure. The architecture includes an App Service Environment and Azure Virtual Machines that utilize service endpoints to allow access to the SQL DB and Azure Storage.](images/Hands-onlabunguided-SecuringPaaSimages/media/image2.png "High-level solution architecture diagram")

The solution begins with a deployed template of typical and not so typical resources. Due to time restraints during deployment you will have an internal (versus an external facing) **App Service Environment** (ASE). The ASE will have no app service plans or apps deployed to it. It is also not accessible from the outside world. You will configure an application to be deployed using the **Azure DevOps** machine and Visual Studio to deploy to the ASE after creating an app service plan. Once deployed, you will then configure the **Application Gateway** to point to the new ASE hosted App. Once configured you will perform a typical web-based attack on the environment in a detection-only mode to see the requests pass to your web application. Once you understand how this process works, you will then enable the **Web Application Firewall** to filter requests based on the **OWASP 3.0** standard and see that those requests are in fact blocked.

Separately you will explore how Azure IAM works and how those access permissions are separate from policies that may live within the actual Azure resource (such as with **Azure Key Vault**). You will learn how to remove sensitive information from your various resources such as **Azure Functions** and **Web Applications** and place them in the **Azure Key Vault** for both deployment and runtime use.

As a final step, you will learn how to perform queries as **Log Analytics** to populate a **Power BI** report based on your **Web Application Firewall** events.

## Requirements

1.  Microsoft Azure subscription must be pay-as-you-go or MSDN

    a.  Trial subscriptions will *not* work.

2.  A machine with the following software installed:

    b.  Visual Studio 2017 Community edition or greater

    c.  SQL Management Studio 2017

    d.  Power BI Desktop

    e.  Fiddler

**To ensure you can begin the course delivery on-time, you must take the following step at least 5-hours prior to the course start time:**

>**Note**: Run the Azure resource template -- The Application Service Environment can take more than 90-minutes to create.

## Exercise 1: Creating and securing Azure Active Directory accounts

Duration: 45 minutes

Synopsis: In this exercise, attendees will learn how to create Azure Active Directory (Azure AD) groups and users and then securing them using multi-factor authentication.

>**Note**: If you are using a corporate Azure instance and do not have access to Active Directory, you must skip this Exercise and move to [Exercise 3](#exercise-3-azure-deployments-using-azure-key-vault).

### Task 1: Create Azure Active Directory groups

#### Tasks to Complete

-   Create two Active Directory Groups, one for key vault management users and the other for key vault key admins.

#### Exit Criteria

-   Two new active directory groups created

### Task 2: Create Azure Active Directory accounts

#### Tasks to Complete

-   Create three new Active Directory accounts, one for admin, auditor and developer.

#### Exit Criteria

-   Three new Active Directory accounts created

### Task 3: Enable Azure Identity Protection features 

#### Tasks to Complete

-   Enable the admin account to be multi-factor authentication enabled.

#### Exit Criteria

-   An admin account with MFA enabled

## Exercise 2: Securing Azure Key Vault with Azure IAM

Duration: 45 minutes

Synopsis: In this exercise, attendees will learn how to create various roles for managing the Azure Key Vault.

>**Note**: If you are using a corporate Azure instance and do not have access to Active Directory, you must skip this Exercise and move to Exercise 3.

### Task 1: Create a new Azure Key Vault

#### Tasks to Complete

-   Create a new Azure Key Vault.

#### Exit Criteria

-   A new Azure Key Vault

### Task 2: Assign IAM based Azure Key Vault permissions

#### Tasks to Complete

-   Assign the admin users the Key Vault Contributor rights on the key vault.

-   Assign the auditor user Read rights on the key vault.

#### Exit Criteria

-   Rights assigned to admin and auditor users

### Task 3: Assign access policy based Azure Key Vault permissions

#### Tasks to Complete

-   Assign the List permission to the Key Vault Auditor user.

#### Exit Criteria

-   Key Vault Auditor has ability to list the keys in the vault

### Task 4: Verify Azure Key Vault permissions

#### Tasks to Complete

-   Prove that you can assign yourself key vault policies as the admin user.

-   Verify that the developer user cannot see the key vault.

-   Verify that the auditor can see the key vault but cannot assign any permissions.

#### Exit Criteria

-   All items above are true

## Exercise 3: Azure deployments using Azure Key Vault

Duration: 45 minutes

Synopsis: In this exercise, attendees will utilize the Microsoft.Compute deployment access that was given in the previous exercise to gain access to an Azure Key Vault secret and certificate without saving them in the template(s).

### Task 1: Create new secrets

#### Tasks to Complete

-   Create two new Azure Key Vault secrets -- VMUsername, VMPassword.

#### Exit Criteria

-   Two new key vault secrets are available in the key vault.

### Task 2: Deploy an ARM Template using Azure Key Vault resources

#### Tasks to Complete

-   Create an Azure Resource Manager template(s) that will create an Azure SQL Server using the admin username and password from the key vault.

#### Exit Criteria

-   A new Azure resource manager template with Azure Key Vault references

-   A new Azure SQL Server created using the Azure Key Vault secrets

## Exercise 4: Securing the web application and database

Duration: 45 minutes

Synopsis: In this exercise, attendees will utilize Azure SQL features to data mask database data and utilize Azure Key Vault to encrypt sensitive columns for users and applications that query the database.

### Task 1: Setup the database

#### Tasks to Complete

-   Deploy the GitHub FourthCoffee.dacpac database to the Azure SQL Server.

#### Exit Criteria

-   New Azure SQL Database created based on the dacpac file

### Task 2: Test the web application solution

#### Tasks to Complete

-   Open the WebApp\\FourthCoffeeAPI\\FourthCoffeeAPI.sln.

-   Modify the web.config to point to your newly created database.

-   Ensure that the web application pulls data from the web app successfully via the [http://localhost:\[PORT-NUMBER\]/api/CustomerAccounts](http://localhost:[PORT-NUMBER]/api/CustomerAccounts) URL.

#### Exit Criteria

-   Web application that pulls data from the Azure SQL database successfully

### Task 3: Utilize data masking

#### Tasks to Complete

-   Enable data masking for the CustomerAccount.CreditCard column.

#### Exit Criteria

-   Refresh the web application page and ensure that the credit card value is masked.

### Task 4: Utilize column encryption with Azure Key Vault

#### Tasks to Complete

-   Modify the CreditCard column to be encrypted rather than masked.

#### Exit Criteria

-   The Credit Card number is encrypted via a select \* query.

### Task 5: Enable SQL Azure Auditing & Threat Detection

#### Tasks to Complete

-   Enable SQL Azure Auditing and Threat Detection on the FourthCoffee database.

#### Exit Criteria

-   Azure Auditing and Threat Detection is enabled.

### Task 6: Ensure SQL Azure Transparent Data Encryption (TDE) is enabled

#### Tasks to Complete

-   Ensure that Azure Transparent Data Encryption is enabled on the Fourth Coffee database.

#### Exit Criteria

-   Azure TDE is enabled.

## Exercise 5: Migrating web.config settings to azure key vault

Duration: 30 minutes

Synopsis: In this exercise, attendees will learn how to migrate web application to utilize Azure Key Vault rather than storing valuable credentials (such as connection strings) in application configuration files.

### Task 1: Create an Azure Key Vault secret

#### Tasks to Complete

-   Copy the connection string from the web application web.config file.

-   Create an Azure Key Vault secret using the connection string as its value.

#### Exit Criteria

-   A new Azure Key Vault secret value that is a connection string

### Task 2: Create an Azure Active Directory application

#### Tasks to Complete

-   Create an Azure AD application.

-   Create a client secret.

-   Record the application id and client secret.

#### Exit Criteria

-   A new Azure AD Application is created.

### Task 3: Assign the new Application Azure Key Vault Permissions

#### Tasks to Complete

-   Assign the newly created Azure AD application access to the key vault to secrete your created in task 1.

#### Exit Criteria

-   Azure AD Application has access to the key vault secret.

### Task 4: Install NuGet packages

#### Tasks to Complete

-   Ensure that the /WebApp/FourthCoffeeAPI\_KeyVault/FourthCoffeeAPI.sln compiles.

#### Exit Criteria

-   A successfully compiled web application

### Task 5: Test the solution

#### Tasks to Complete

-   Update the web application to use the client id and secrete to get an access token which is then used to retrieve the value from the key vault.

-   The connections string should be fed into the entity framework application.

-   The web application should load and retrieve the data successfully.

#### Exit Criteria

-   A web application that uses Azure AD Application to successfully gain access to a key vault secrete and load the CustomerAccount API endpoint.

## Exercise 6: Securing PaaS web applications with App Service Environment and Web Application Firewall 

Duration: 45 minutes

Synopsis: In this exercise, attendees will deploy a cloud web application with a web application gateway and firewall enabled.

### Task 1: Deploy web application to app service environment

#### Tasks to Complete

-   Create an App Service Plan for your App Service Environment.

-   Deploy the /WebApp/FourthCoffeeWeb to the App Service Plan.

#### Exit Criteria

-   A successfully ASE deployed web application

### Task 2: Configure the Web Application Firewall

#### Tasks to Complete

-   Ensure that the web application is configured to have the ASE internal load balancer IP address as the backend pool.

-   Ensure that the http listener is configured with a health probes that resolves the web application host header.

#### Exit Criteria

-   You have a web application gateway that responds to web application requests to your deployed web site.

### Task 3: Enable Application Gateway logging

#### Tasks to Complete

-   Enable the diagnostic logging for the application gateway.

#### Exit Criteria

-   Diagnostic logging is turned on for the application gateway.

### Task 4: Attack a ASE Web Application with Detection Only

#### Tasks to Complete

-   Use the /Scripts/WebAttack.ps1 script to attack your newly deployed web application.

#### Exit Criteria

-   A series of "successful" attacks on the web application

### Task 5: Enable Web Application Firewall Prevention

#### Tasks to Complete

-   Switch the firewall from detection mode to prevention mode.

#### Exit Criteria

-   A web application firewall in prevention mode

### Task 6: Reattack an ASE Web Application with Prevention enabled

#### Tasks to Complete

-   Use the /Scripts/WebAttack.ps1 script to attack your newly deployed web application.

#### Exit Criteria

-   Successfully blocked http requests based on OWASP filtering rules

## Exercise 7: Securing Azure Functions with Managed Service Identities 

Duration: 30 minutes

Synopsis: In this exercise, attendees will learn how to use Azure Functions that access Azure Key Vault as a Managed Service Identity.

### Task 1: Create an Azure Function

#### Tasks to Complete

-   Create a new Azure Function with an HTTP Trigger.

-   Use the /AzureFunction/\* files to build the function.

#### Exit Criteria

-   A new Azure Function using an HTTP Trigger

### Task 2: Create a Managed Service Identity

#### Tasks to Complete

-   Enable the Managed Service Identity feature for the Azure Function.

#### Exit Criteria

-   MSI is enabled for the Azure Function.

### Task 3: Assign Managed Service Identity Azure Key Vault Permissions

#### Tasks to Complete

-   Create a new secret in the key vault.

-   Assign the MSI access to the Azure Key Vault and the newly created secret.

#### Exit Criteria

-   An MSI with access to an Azure Key Vault secret

### Task 4: Test your Azure Function

#### Tasks to Complete

-   Run your function, ensure that it is able to gain access to the Key Vault secret value.

#### Exit Criteria

-   An Azure Function that successfully accesses and displays an Azure Key Vault secret

## Exercise 8: Creating PaaS Audit and Compliance Power BI Reports 

Duration: 20 minutes

Synopsis: In this exercise, attendees will learn to utilize the Log Analytics feature of Azure to create Power BI Reports.

### Task 1: Export a Power Query formula from Log Analytics

#### Tasks to Complete

-   Use Log Analytics to query for the security events created from the Web Application Firewall in the previous exercises.

-   Create a Power BI report using the log analytics data.

#### Exit Criteria

-   A Power BI report that uses Log Analytics to get Web Application Firewall data

## After the hands-on lab 

Duration: 10 minutes

In this exercise, attendees will deprovision any Azure resources that were created in support of the lab.

### Task 1: Delete resource group

1.  Using the Azure portal, navigate to the Resource group you used throughout this hands-on lab by selecting **Resource groups** in the left menu.

2.  Search for the name of your research group and select it from the list.

3.  Select **Delete** in the command bar and confirm the deletion by re-typing the Resource group name and selecting **Delete**.

### Task 2: Delete Azure AD objects

1.  Navigate to Azure Active Directory in the Azure portal.

2.  Delete the groups you created:

    a.  Key Vault Mgmt Admins

    b.  Key Vault Key Admins

3.  Delete the users you created:

    a.  Key Vault Admin

    b.  Key Vault Auditor

    c.  Key Vault Developer

4.  Delete the App you registered:

    a.  Select App registrations.

    b.  Select View all applications.

    c.  Select and delete the AzureKeyVaultTest app.

### Task 3: Delete lab environment (optional)

1.  If you are using a hosted platform, make sure you shut it down/delete it.

You should follow all steps provided *after* attending the Hands-on lab.

