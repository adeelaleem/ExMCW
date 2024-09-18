![](images/HeaderPic.png "Microsoft Cloud Workshops")

# Optimized architecture

## Hands-on lab step-by-step

## March 2018

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.
© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.


## Contents 


-   [Abstract and learning objectives](#abstract-and-learning-objectives)
-   [Overview](#overview)
-   [Requirements](#requirements)
-   [Solution architecture](#solution-architecture)
-   [Before the hands-on lab](#before-the-hands-on-lab)
    -   [Task 1: Create a virtual machine for your lab environment](#task-1-create-a-virtual-machine-for-your-lab-environment)
    -   [Task 2: Disable IE Enhanced Security](#task-2-disable-ie-enhanced-security)
    -   [Task 3: Download the Sample App Files](#task-3-download-the-sample-app-files)
    -   [Task 4: Deploy Sample App and "Existing" environment](#task-4-deploy-sample-app-and-existing-environment)
-   [Exercise 1: Determine Appropriate App Service Tiers and Estimate Cost Savings](#exercise-1-determine-appropriate-app-service-tiers-and-estimate-cost-savings)
    -   [Help references](#help-references)
    -   [Scenario](#scenario)
    -   [Task 1: Calculate Estimated Hosting Cost of Existing Solution](#task-1-calculate-estimated-hosting-cost-of-existing-solution)
    -   [Task 2: Calculate Estimated Hosting Cost of VMs with Reserved instances](#task-2-calculate-estimated-hosting-cost-of-vms-with-reserved-instances)
    -   [Task 3: Estimate Necessary App Service Tiers](#task-3-estimate-necessary-app-service-tiers)
    -   [Task 4: Calculate Estimated Hosting Cost of Azure App Service](#task-4-calculate-estimated-hosting-cost-of-azure-app-service)
    -   [Task 5: Calculate Estimated Cost Savings](#task-5-calculate-estimated-cost-savings)
-   [Exercise 2: Integrate Traffic Manager](#exercise-2-integrate-traffic-manager)
    -   [Help references](#help-references-1)
    -   [Task 1: Create Traffic Manager](#task-1-create-traffic-manager)
    -   [Task 2: Point Traffic Manager to External / Internet Load Balancer](#task-2-point-traffic-manager-to-external-internet-load-balancer)
-   [Exercise 3: Setup API Tier in Azure App Service](#exercise-3-setup-api-tier-in-azure-app-service)
    -   [Help references](#help-references-2)
    -   [Step 1: Create App Service for Web API Tier](#step-1-create-app-service-for-web-api-tier)
    -   [Step 2: Setup App Settings](#step-2-setup-app-settings)
    -   [Step 3: Deploy API to App Service](#step-3-deploy-api-to-app-service)
-   [Exercise 4: Migrate Web App Tier to App Service](#exercise-4-migrate-web-app-tier-to-app-service)
    -   [Help references](#help-references-3)
    -   [Step 1: Create App Service for Web App Tier](#step-1-create-app-service-for-web-app-tier)
    -   [Step 2: Setup App Settings](#step-2-setup-app-settings-1)
    -   [Step 3: Deploy App to Web App](#step-3-deploy-app-to-web-app)
    -   [Step 4: Add Web App to Traffic Manager](#step-4-add-web-app-to-traffic-manager)
    -   [Step 5: Take down Web App and API VMs](#step-5-take-down-web-app-and-api-vms)
-   [Exercise 5: Migrate Background Tier to App Service](#exercise-5-migrate-background-tier-to-app-service)
    -   [Help references](#help-references-4)
    -   [Step 1: Create App Service for Background Tier](#step-1-create-app-service-for-background-tier)
    -   [Step 2: Setup App Settings](#step-2-setup-app-settings-2)
    -   [Step 3: Deploy App to App Service](#step-3-deploy-app-to-app-service)
    -   [Step 4: Take down Background Tier VM](#step-4-take-down-background-tier-vm)
-   [Exercise 6: Setup SQL Database Geo-Replication](#exercise-6-setup-sql-database-geo-replication)
    -   [Help references](#help-references-5)
    -   [Step 1: Setup SQL Database Geo-Replication](#step-1-setup-sql-database-geo-replication)
-   [Exercise 7: Take down old architecture resources](#exercise-7-take-down-old-architecture-resources)
    -   [Step 1: Remove Old VM-based tiers](#step-1-remove-old-vm-based-tiers)
-   [Exercise 8: Setup European Web App Tier Instance](#exercise-8-setup-european-web-app-tier-instance)
    -   [Help references](#help-references-6)
    -   [Step 1: Create European App Service](#step-1-create-european-app-service)
    -   [Step 2: Set App Settings](#step-2-set-app-settings)
    -   [Step 3: Deploy Web App to European Region](#step-3-deploy-web-app-to-european-region)
    -   [Step 4: Add European Region to Traffic Manager](#step-4-add-european-region-to-traffic-manager)
-   [After the hands-on lab ](#after-the-hands-on-lab)
    -   [Task 1: Delete Resources](#task-1-delete-resources)


## Abstract and learning objectives 

In this workshop, students will learn how to optimize a lift and shift
style IaaS architecture in Azure to improve cost savings. You will also
compare IaaS and PaaS hosting options to save cost even further using
Azure App Service. Additionally, students will learn to improve
resiliency and high availability through multi-region deployment.

Attendees will learn how to:

-   Optimize Azure IaaS for cost savings

-   Migrate an Azure IaaS optimized

-   Compare cost between Azure IaaS versus Azure PaaS

-   Setup SQL Database geo-replication

-   Configure multi-region deployment

## Overview

The Optimized Architecture hands-on lab (HOL) is a hands-on exercise
that will challenge you to calculate Azure spending optimizations by
comparing IaaS and PaaS services using a supplied sample application (a
3-tier application written in C\# and ASP.NET MVC) that is based on
Microsoft Azure IaaS services such as Virtual Machines, Virtual Network,
Load Balancers, Storage and SQL Database. In addition to calculating
estimated Azure cost of the existing architecture, you will need to
calculate the estimated cost of hosting the sample application using
Azure PaaS services. The scenario will include migrating the full sample
application to be hosted on Azure PaaS services such as Azure App
Service Web Apps, Web Jobs, and Traffic Manager as well as implementing
a secondary hosting region for the Web App tier and database
replication.

The HOL can be implemented on your own, but it is highly recommended to
pair up with other members at the HOL to model a real-world experience
much closer and to allow each member to share their expertise for the
overall solutions.

## Solution architecture

![Using traffic
manager](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image2.png "Solution architecture")


## Requirements

1.  Microsoft Azure subscription

2.  Local machine or a virtual machine configured with Visual Studio
    2017 Community Edition or better


## Before the hands-on lab

Duration: 20 minutes

In this exercise, you will set up an environment to use for the rest of
the exercises.

#### Task 1: Create a virtual machine for your lab environment 

1.  Launch a browser using incognite or in-private mode, and navigate to
    <https://portal.azure.com>. Once prompted, login with your Microsoft
    Azure credentials. If prompted, choose whether your account is an
    organization account or just a Microsoft Account.

2.  Click on +NEW, and in the search box, type in Visual Studio
    Community 2017 on Windows Server 2016 (x64), and press enter. Click
    the Visual Studio Community 2017 image running on Windows Server
    2016 and with the latest update.

3.  In the returned search results, click the image name.

    ![In the Everything blade, Visual Studio Community 2017 is typed in
    the Search field. Under Name, Visual Studio Community on Windows
    Server 2016 is
    circled.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image3.png "Everything blade")

4.  In the Marketplace solution blade, click **Create**.

5.  Set the following configuration on the Basics tab, and click **OK**.

    -   Name: **LABVM**

    -   VM disk type: **SSD**

    -   User name: **demouser**

    -   Password: **demo@pass123**

    -   Subscription: **If you have multiple subscriptions choose the
        subscription to execute your labs in.**

    -   Resource Group: **OPSLABRG**

    -   Location: **Choose the closest Azure region to you.**

6.  Choose the **DS1\_V2 Standard** instance size on the Size blade.

7.  Accept the remaining default values on the Settings blade, and click
    **OK**. On the Summary page, click **OK**. The deployment should
    begin provisioning. It may take more than 10 minutes for the virtual
    machine to complete provisioning.

    ![Screenshot of the Deploying Visual Studio Community 2017
    icon.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image4.png "Deploying Visual Studio Community 2017 icon")

#### Task 2: Disable IE Enhanced Security

Note: Sometimes this image has IE ESC disabled. Sometimes it does not.

1.  On the new VM, you just created, click the **Server Manager** icon.

    ![Screenshot of the Server Manager
    icon.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image5.png "Server Manager icon")

2.  Click **Local Server**.

    ![Local Server is selected from the Server Manager icon drop-down
    menu.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image6.png "Server Manager icon drop-down menu")

3.  On the right side of the pane, click **On** by IE Enhanced Security
    Configuration.

    ![IE Enhanced Security Configuration is set to
    On.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image7.png "IE Enhanced Security Configuration")

4.  Change to **Off** for Administrators, and click **OK**.

    ![In the Internet Explorer Enhanced Security Configuration Dialog
    box, Administrators is set to
    Off.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image8.png "Internet Explorer Enhanced Security Configuration Dialog box")

#### Task 3: Download the Sample App Files 

1.  Create a new folder on your C: drive named **HOL**.

2.  Download the sample application and ARM template
    (optimized-architecture-student.zip) from here:
    <https://cloudworkshop.blob.core.windows.net/optimized-architecture/OptimizedArchitecture-StudentFiles-6-2017.zip>.

3.  Right click on the downloaded .zip file, and click **Properties**.
    On the properties pane, check **Unblock** to ensure the files are
    marked safe.

4.  Extract the zip file contents to the **HOL** folder.

5.  From the **ARMTemplate** folder under **HOL**, open the Visual
    Studio Solution file: **Contoso.Financial.ARMTemplate.sln**.

#### Task 4: Deploy Sample App and "Existing" environment

1.  From the *C:\\HOL\\ARMTemplate* folder, open the Visual Studio
    Solution: **Contoso.Financial.ARMTemplate.sln**

2.  In the **Solution Explorer** window, right-click on the
    **Contoso.Financial.ARMTemplate** project, click **Deploy**, and
    then click **New...\
    **\
    ![In Solution Explorer, Contoso.Financial.ARMTemplate is selected.
    From its right-click menu, Deploy / New is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image9.png "Solution Explorer")

3.  If your Microsoft or Organization account for your Azure
    Subscription has not been added to Visual Studio yet, click on **Add
    an account**, then **Add an account...**, and follow the prompts to
    login.
    
    ![Add an account is selected in the Deploy to Resource Group
    dialog
    box.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image10.png "Deploy to Resource Group dialog box")

4.  Click on the **Resource group** dropdown, followed by selecting
    **\<Create New...\>**.

    ![In the Deploy to Resource Group dialog box, Create New is selected
    from the Resource group drop-down
    menu.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image11.png "Deploy to Resource Group dialog box")

5.  On the **Create Resource Group** dialog, enter the following values:

    -   Resource group name: **ContosoExistingRG**

    -   Resource group location: **North Central US (note if your
        subscription allows this otherwise pick up subscription where
        you are allowed to deploy to)**

        ![Fields in the Create Resource Group dialog box are set to the
        previously defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image12.png "Create Resource Group dialog box")

6.  Click the **Create** button.

7.  In the **Deploy to Resource Group** dialog, click the **Deploy**
    button to deploy the ARM Template to the newly created Resource
    Group.

    ![In the Deploy to Resource Group dialog box, the Deploy button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image13.png "Deploy to Resource Group dialog box")

8.  Deployment status of the ARM Template will be displayed in the
    **Output** window within Visual Studio.

    ![Deployment status displays in the Visual Studio Output
    Window.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image14.png "Visual Studio Output Window")

9.  Once the deployment has completed successfully, the **IP Address**
    and **FQDN** of the External / Internet Load Balancer for the Web
    App tier will be displayed in the output window.

    ![The IP Address for the External / Internal Load Balancer are
    circled in the Output
    Window.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image15.png "Output Window")

> The **Username** and **Password** for the VMs and SQL Database created
by the ARM Template are:
> - Username: **demouser**
> - Password: demo@pass123

10.  Open a new **Web Browser** window, and navigate to the Web App tier
    using the **Internet Load Balancer IP Address**.\
    \
    ![The Contoso Financial Login webpage
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image16.png "Contoso Financial Login webpage")

11.  To login to the Web App Tier of the Contoso Financial sample
    application, simply enter **any email address and password**
    followed by clicking on **Sign in**. If you can't immediately sign
    in, give the site a few minutes to run the background process and
    then attempt to sign in again.

12.  Once logged in, the sample application will display a simple
    **Account Transaction** ledger.\
    \
    ![The Contoso Financial Account Overview webpage displays with
    Transaction details in an account transaction
    ledger.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image17.png "Contoso Financial Account Overview webpage")

> Leaving the browser open to the Account Overview page will automatically
load new transactions as they are generated by the background process,
since the web page has a JavaScript timer that checks for new
transactions periodically. 
You should follow all steps provided **before** attending the
HOL.

## Exercise 1: Determine Appropriate App Service Tiers and Estimate Cost Savings

Contoso Financial has asked you to optimize their Azure spending by
migrating their existing Azure IaaS based architecture over to Azure
PaaS services. You will need to determine the appropriate hosting tiers
and estimate the total cost savings on a monthly and annual basis.

#### Help references
 
|         |            |
| ------------- |:-------------:|
| Azure Pricing Calculator    | <https://azure.microsoft.com/en-us/pricing/calculator> |
| Virtual Machines Pricing    | <https://azure.microsoft.com/en-us/pricing/details/virtual-machines/>  |
| App Service Pricing         | <https://azure.microsoft.com/en-us/pricing/details/app-service> |

#### Scenario

Contoso Financial recently performed a lift-and-shift to move their
application into Microsoft Azure using the North Central US region. As a
result, the existing architecture of the application is implemented with
Virtual Machines, Load Balancers, Availability Sets, SQL Database, and a
Virtual Network.

![The current scenario diagram for Contoso Financial has three users on
the internet passing through an external load balancer to access the
Availability Set (Web App) with two virtual machines. Both the first
availability set, and a second availability set (background processes)
pass through an internal load balancer to a third availability set (Web
API). A SQL Database shares bi-directional access with the Web API
availability set. All three availability sets are subnets of a VNet,
which is in the Azure North Central US
Region.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image18.png "Current scenario diagram")

You have also been provided with the following metrics showing the
average CPU / RAM utilization of the Virtual Machines hosting the
solution that are all on the Standard D3 pricing tier.

When calculating the pricing for the environment, there may be some
differences depending if you use the prices listed in the Azure Portal
or the Azure Pricing Calculator.

![In this Standard D3 pricing tier, the first row is Front-End Web App
Tier, which offers CPU of 36 percent and RAM of 46 percent, or CPU of 38
percent or RAM of 44 percent. The second row is the Back-End Web App
Tier, which has CPU of 58 percent and RAM of 34 percent, or CPU of 56
percent or RAM of 31 percent. The third row is Back-end processing tier,
which is CPU of 49 percent, and RAM of 25 percent. The bottom row,
Database Server SQL Database: Premium P4, has no CPU or RAM
information.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image19.png "Standard D3 pricing tier")

Additionally, the Azure SQL Database is hosted using the Premium P4
pricing tier.

The VM sizes from the Existing architecture that was deployed using the
ARM Template will be slightly different from the diagram above for this
scenario. The reason for this was to make the ARM Template deployment
quicker and cheaper while still deploying enough to allow you to perform
the exercises in this lab.

#### Task 1: Calculate Estimated Hosting Cost of Existing Solution

1.  From a new browser tab or instance, navigate to the **Azure Pricing
    Calculator** <https://azure.microsoft.com/en-us/pricing/calculator>.

2.  Click on **Compute**, followed by **Virtual Machines**.
    
    \
    ![On the Azure Pricing Calculator webpage, Compute and Virtual
    Machines are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image20.png "Azure Pricing Calculator webpage")
    

3.  Click on **Databases**, followed by **SQL Database**.\
    \
    ![On the Azure Pricing Calculator webpage, Databases and SQL
    Database are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image21.png "Azure Pricing Calculator webpage")

4.  Scroll down to the **Your Estimate** section of the page.
    
    ![The Your Estimate section
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image22.png "Your Estimate section")

5.  On the **SQL Database**, set the following values:

    -   Region: **North Central US**

    -   Pricing Tier: **Premium**

    ![In the SQL Database section, North Central US is selected for the
    region, and Premium is selected for the
    Tier.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image23.png "SQL Databases section")

6.  Set the **Performance Level** to **P4**.
    
    ![The Performance Level field is set to P4: 500 DTUs, 500 GB
    included storage per DB,
    \$2.5000/hour](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image24.png "Performance Level Field")

7.  On **Virtual Machines**, set the following values:

    -   Region: **North Central US**

    -   Pricing Tier: **Standard**

    ![Under Virtual Machines, Region is set to North Central US\< and Tier
    is
    Standard.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image25.png "Virtual Machines section")

8.  Change the **Instance Size** to **D3**.
    
    ![The Instance field is set to D3: 4 vCPU(s), 14 GB RAM, 200 GB
    Temporary storage,
    \$0.560/hour.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image26.png "Instance field")

9.  Change the **Billing Option** to **Pay as you go**, and change the
    **Virtual Machines Count** to **5**. The count now includes the 2x
    Web App Tier, 2x API Tier, and 1x Background Tier virtual machines.
    
    ![Under Billing Option, Pay as you go is selected. The number of
    virtual machines is set to 5, multiplied by 732 hours, for a total
    of
    \$2,049.60.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image27.png "Billing Option section")

10. Click the **Collapse all** button, and Record the **Estimated
    monthly cost**. This is the total estimated cost of the existing
    environment Virtual Machines and SQL Database only.
    
    ![On the Your Estimate page, the estimate of $3,879.60 in US
    Dollars is circled, as is the collapse all button (two arrows in a
    circle pointing in toward each
    other).](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image28.png "Your Estimate page")

#### Task 2: Calculate Estimated Hosting Cost of VMs with Reserved instances

1.  From a new browser tab or instance, navigate to the **Azure Pricing Calculator** <https://azure.microsoft.com/en-us/pricing/calculator>.

2.  Click on **Compute**, followed by **Virtual Machines**.
    
    ![On the Azure Pricing Calculator webpage, Compute, and Virtual
    Machines are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image20.png "Azure Pricing Calculator webpage")

3.  Click on **Databases**, followed by **SQL Database**.
    
    ![On the Azure Pricing Calculator webpage, Databases, and SQL
    Database are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image21.png "Azure Pricing Calculator webpage")

4.  Scroll down to the **Your Estimate** section of the page.
    
    ![On the Azure Pricing Calculator webpage, the Your Estimate section
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image22.png "Azure Pricing Calculator webpage")

5.  On the **SQL Database**, set the following values:

    -   Region: **North Central US**

    -   Pricing Tier: **Premium**

    ![In the SQL Database section, Region is set to North Central US, and
    Tier is
    Premium.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image23.png "SQL Database section")

6.  Set the **Performance Level** to **P4**.
    
    ![The Performance Level field is set to P4: 500 DTUs, 500 GB
    included storage per DB,
    \$2.5000/hour.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image24.png "Performance Level field")

7.  On **Virtual Machines**, set the following values:

    -   Region: **North Central US**

    -   Pricing Tier: **Standard**

    ![In the SQL Database section, Region is set to North Central US, and
    Tier is
    Standard.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image25.png "Virtual Machines section")

8.  Change the **Instance Size** to **D3**.
    
    ![The Instance field is set to D3: 4 vCPU(s), 14 GB RAM, 200 GB
    Temporary storage,
    \$0.560/hour.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image26.png "Instance field")

9.  Change the **Billing Option** to **3-year reserved**, and change the
    **Virtual Machines Count** to **5**, so the count includes the 2x
    Web App Tier, 2x API Tier, and 1x Background Tier virtual machines.

    ![In the Billing Option section, the 3 year reserved option is
    selected. Virtual machines is set to 5, and the total amount is
    \$1,054.83.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image29.png "Billing Option section")

10. Click the **Collapse all** button, and Record the **Estimated
    monthly cost**. This is the total estimated cost of the existing
    environment Virtual Machines and SQL Database only using **Reserved     Instances**. 
          
    ![On the Your Estimate page, the collapse all button is selected.
    Below that, the the SQL Database cost is \$1,830.00, the Virtual
    Machines are \$1,054.83, and the estimated monthly cost is
    \$2,884.83.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image30.png "Your Estimate page")

#### Task 3: Estimate Necessary App Service Tiers

##### Subtask 1: Find Existing VM Instance Size Specifications (CPU Cores and RAM)

1.  From a new browser tab or instance, navigate to the **Windows**
    **Virtual Machines Pricing** page.\
    <https://azure.microsoft.com/en-us/pricing/details/virtual-machines/windows/>

2.  Scroll down to the **Explore all VM options** section of the page.
    
    ![The Explore all VM options section of the Windows Virtual Machines
    Pricing webpage
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image31.png "Windows Virtual Machines Pricing webpage")

3.  Set the **OS/Software** drop down to **Windows OS**, and the
    **Region** to **North Central US**.

    ![In the Explore all VM options section, OS/Software is set to
    Windows OS, Region is North Central US, and Pricing will be
    displayed by
    hour.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image32.png "Explore all VM options section")

4.  Click on **General purpose**.\
    \
    ![At the bottom of the Explore all VM options section, the General
    purpose category is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image33.png "Explore all VM options section")

5.  Scroll down below the VM Instance Size listings, and click on the
    **Check the Previous Generation page...** link.

    ![Screenshot of the Check the Previous Generation page for ...
    link](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image34.png "Check the Previous Generation page link")

6.  Scroll down to the **D1-4 v1** section and make note of the VM
    Instance specs, specifically the **CPU Cores** and **RAM** for the
    **D3** instance size.

    ![In the D1-4 - v1 section, The D3 instance is circled, with the
    following values: vCPU, 4; RAM, 14.00GiB; Temporary Storage,
    200GiB.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image35.png "D1-4 - v1 section")

##### Subtask 2: Calculate Web App Tier VM Utilization

1.  Calculate the **Average CPU Utilization** between the 2 Web App Tier
    VMs with individual CPU utilization of **36%** and **38%**.

    -   36 + 38 = 74

    -   74 / 2 = **37% Average CPU Utilization**

    ![The Front-end Web App Tier percentages for VM Size Standard D3, CPU
    is 36 percent and RAM 46 percent, or CPU 38 percent and RAM 44
    percent.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image36.png "Front-end Web App Tier percentages")

1.  Calculate the amount of **CPU Cores** the **Average CPU
    Utilization** represents:

    -   **4** (CPU Cores) **\* 0.37** (37%) = 1.48 CPU Cores

2.  Calculate the **Average RAM Utilization** between the 2 Web App Tier
    VMs with individual RAM Utilization of **46%** and **44%**.

    -   46 + 44 = 90

    -   90 / 2 = **45% Average RAM Utilization**

3.  Calculate the amount of **RAM** the **Average RAM Utilization**
    represents:

    -   **14 GB** (RAM) **\* 0.45** (45%) **= 6.3 GB RAM**

##### Subtask 3: Calculate API Tier VM Utilization

1.  Calculate the **Average CPU Utilization** between the 2 API Tier VMs
    with individual CPU utilization of **58%** and **56%**.

    -   58 + 56 = 114

    -   114 / 2 = **57% Average CPU Utilization**

    ![The Back-end Web App Tier percentages for VM Size Standard D3, CPU
    is 58 percent and RAM 34 percent, or CPU 56 percent and RAM 31
    percent.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image37.png "Back-end Web App Tier percentages")

2.  Calculate the amount of **CPU Cores** the **Average CPU Utilization** represents:

    -   **4** (CPU Cores) **\* 0.57** (57%) **= 2.28 CPU Cores**

3.  Calculate the **Average RAM Utilization** between the 2 API Tier VMs
    with individual RAM utilization of **34%** and **31%**.

    -   34 + 31 = 65

    -   65 / 2 = **32.5% Average RAM Utilization**

4.  Calculate the amount of **RAM** the **Average RAM Utilization**
    represents:

    -   **14 GB** (RAM) **\* 0.325** (32.5%) **= 4.55 GB RAM**

##### Subtask 4: Calculate Background Tier VM Utilization

1.  The **Average CPU Utilization** of the single Background Tier VM is
    **49%**.
    
    ![The Back-end Processing Tier percentages for VM Size Standard D3,
    CPU is 49 percent and RAM 25
    percent.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image38.png)

2.  Calculate the amount of **CPU Cores** the **Average CPU Utilization** represents:

    a.  **4** (CPU Cores) **\* 0.49** (49%) **= 1.96 CPU Cores**

3.  The **Average RAM Utilization** of the single Background Tier VM is
    **25%**.

4.  Calculate the amount of **RAM** the **Average RAM Utilization**
    represents:

    a.  **14 GB** (RAM) **\* 0.25** (25%) **= 3.5 GB RAM**

##### Subtask 5: Identify Appropriate App Service Tier

1.  From a new browser tab or instance, navigate to the **App Service     Pricing** page
    <https://azure.microsoft.com/en-us/pricing/details/app-service>

2.  Set the **Region** filter to **North Central US**.
    
    ![On the the App Service Pricing page, Region is set to North
    Central US, and Currency is US Dollar
    (\$).](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image39.png "App Service Pricing page ")

3.  Scroll down to the **Standard Service Plan** section.

    ![The Standard Service Plan section displays a table of service plan
    instances, and corresponding number of cores, amount of ram and
    storage, and prices. Instance S1 has 1 core, 1.75 GB RAM, 50 GB
    storage, and costs \$0.10/hour. Instance S2 has 2 cores, 3.50 GB
    RAM, 50 GB storage, and costs \$0.20/hour. Instance S3 has 4 cores,
    7 gb RAM, 50 GB storage, and costs
    \$0.40/hour.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image40.png "Standard Service Plan section")

4.  Map the **CPU / RAM** **Utilization** of the **Web App Tier**
    **(1.48 CPU Cores / 6.3 GB RAM)** to the closest **Standard Service
    Plan** tier. These maps to be the **Standard S3** pricing tier.

5.  Map the **CPU / RAM** **Utilization** of the **API Tier** **(2.28
    CPU Cores / 4.55 GB RAM)** to the closest **Standard Service Plan**
    tier. These maps to be the **Standard S3** pricing tier.

6.  Map the **CPU / RAM** **Utilization** of the **Background Tier**
    **(1.96 CPU Cores / 3.5 GB RAM)** to the closest **Standard Service
    Plan** tier. These maps to be the **Standard S3** pricing tier.

    > The **Background Tier** matches almost identical to 100% of the CPU /
    RAM resources of the **Standard S2** pricing tier. However, 100%
    utilization would hinder the performance of the server since the
    resources would be at their maximum. For this reason, it is appropriate
    to go with the **Standard S3** pricing tier instead to leave extra room
    for best performance and possible spikes in load / usage.

7.  Overall, it has been identified that the **Standard S3** is the
    appropriate **App Service Plan** pricing tier to use for the Web
    App, API, and Background tiers.

#### Task 4: Calculate Estimated Hosting Cost of Azure App Service

1.  From a new browser tab or instance, navigate to the **Azure Pricing
    Calculator** <https://azure.microsoft.com/en-us/pricing/calculator>

2.  Click on **App Service**.

    ![On the Azure Pricing Calculator webpage, Featured and App
    Service are both
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image41.png "Azure Pricing Calculator webpage")
    

3.  If the **SQL Database** is not in the calculator from the previous
    VM estimation, scroll up, add it, and set it to **Premium P4**
    performance level.
    
    ![The SQL Database section displays with the following settings
    Region, East US; Type, Single Database; Tier, Premium; Performance
    Level, P4: 500 DTUs, 500 GB included storage per DB, \$2.5000/hour.
    1 Database multiplied by 732 hours equals \$1,830.00.
    ](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image42.png "SQL Database section")

4.  On **App Service**, change the **Region** to **North Central US**.
    
    ![In the App Service section, Region is set to North Central
    US.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image43.png "App Service section")

5.  Change the **Tier** to **Standard** and the **Instance Size** to
    **S3** to reflect the App Service Plan tier identified as the
    appropriate hosting tier for the Web App, API, and Background
    application tiers.
    
    ![In the App Service Section, Region is North Central US, Tier is
    Standard, and Instance is S3: 4 vCPU(s), 7 GB RAM, 50 GB Storage,
    \$0.400.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image44.png "App Service Section")

6.  Change the **Instances** count to **5** to reflect the same number
    of instances of the existing VM architecture (2x Web App Tier, 2x
    API Tier, 1x Background Tier).
    
    ![At the bottom of the App Service Section, 5 instances multiplied
    by 732 hours equals
    \$1,464.00.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image45.png "App Service section")

    > The **Instance Count** should remain **5** since the application will
    still need the same amount of resources to host; it is just the Azure
    Service hosting them that is changing. For example, since the Web App
    Tier needs 2 VM instances, the App Service Plan will also use 2
    instances for hosting.

7.  Record the **Estimated monthly cost**. This is the total estimated
    cost of the new environment App Service Instances and SQL Database
    only.
    
    ![On the Your Estimate page, the the App Service cost is \$1,464.00,
    the SQL Database cost is \$1,830.00, and the estimated monthly cost
    is \$3,294.00.
    ](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image46.png "Your Estimate page")

#### Task 5: Calculate Estimated Cost Savings

1.  Copy the **Estimated Cost** of the **Existing Architecture** (VMs
    and SQL Database).

    > The original **Existing Architecture** cost that was estimated came to
    approximately **\$6,902**. Your estimate may vary, depending on current
    Azure pricing.

2.  Copy the **Estimated Cost** of the **New Architecture** (App Service
    and SQL Database).

    > The **New Architecture** cost that was estimated came to approximately
    **\$3,582**. Your estimate may vary, depending on current Azure pricing.

3.  **Subtract** the estimated cost of the **New Architecture** from the
    **Existing Architecture** to calculate the **Estimated Monthly Cost
    Savings**.

    -   Existing -- New = Estimated Monthly Cost Savings

    > From the estimates above this would be:
    > \$6,902 - \$3,582 = \$3,320
    > Remember your results may vary, depending on current Azure pricing.

4.  To calculate the **Annual Cost Savings**, take the **Monthly Cost
    Savings** and multiply it by **12**.

    -   Monthly Cost Savings \* 12 = Annual Cost Savings

    > From the estimates above this would be:
    > \$3,320 \* 12 = \$39,840

    > Remember your results may vary, depending on current Azure pricing.

5.  Make note that these **Estimated Cost Savings** do not include
    bandwidth, storage and other charges that will be incurred in
    hosting the application. The estimates calculated above only pertain
    to the **App Service Plans** and **SQL Database**.

    > From the estimates above this would be:
    > - Estimated Monthly Cost Savings: \$3,320
    > - Estimated Annual Cost Savings: \$39,840



## Exercise 2: Integrate Traffic Manager

Contoso Financial needs new load balancing solutions implemented using
Azure Traffic Manager. The existing architecture uses a Load Balancer,
but that does not accommodate the growth of Contoso Financial
appropriately where they will need to add additional hosting regions in
Europe.

#### Help references

|         |            |
| ------------- |:-------------:|
| Azure Load Balancer    | <https://azure.microsoft.com/en-us/services/load-balancer/> |
| Azure Traffic Manager   | <https://azure.microsoft.com/en-us/services/virtual-network>  |



#### Task 1: Create Traffic Manager

1.  From the Azure Management portal <http://portal.azure.com>, using a
    new tab or instance, click on **+New**, type **Traffic Manager**
    into the **Search the marketplace** box and press **Enter**.

    ![In the Azure Portal, New is selected in the left menu. Under New,
    traffic manager is typed in the search box.
    ](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image47.png "Azure Portal")

2.  Click on **Traffic Manager profile** in the list.

    ![In the Everything blade, under Results, Traffic Manager profile is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image48.png "Everything blade")

3.  Click **Create**.

    ![In the Traffic Manager profile window, the Create button is
    circled.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image49.png "Traffic Manager profile window")

4.  On the **Create Traffic Manager profile** blade, enter the following
    values:

    -   Name: **enter a unique name for the Traffic Manager**

    -   Routing method: **Geographic**

    -   Resource group: **Create New -** **OptimizedTFRG**

    -   Resource group location: **North Central US**
      
        ![Fields in the Create Traffic Manager profile blade are set to
        the previously defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image50.png "Create Traffic Manager profile blade")

5.  Click **Create**.

#### Task 2: Point Traffic Manager to External / Internet Load Balancer

1.  Click on **Resource groups**, select the **OptimizedTFRG** resource
    group, and click on the **Traffic Manager** that was just created.

    ![In the left menu of the Azure Portal, the Resource groups icon is
    selected. In the Resource groups blade, under Subscriptions,
    Optimized TFRG is selected. In the Optimized TFRG blade, Overview is
    selected, and under Name, contosowebapp is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image51.png "Azure Portal")

2.  On the **Traffic Manager** blade, click on **Endpoints** under
    Settings.

    ![Screenshot of the Endpoints
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image52.png "Endpoints option")

3.  On the **Endpoints** blade, click on the **Add** button.
    
    ![In the contosowebapp- Endpoints blade, the Add button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image53.png "contosowebapp- Endpoints blade")

4.  On the **Add endpoint** blade, enter the following values:

    -   Type: **Azure endpoint**

    -   Name: **External Load Balancer**

    -   Target resource type: **Public IP address**
       
        ![On the Add endpoint blade, fields are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image54.png "Add endpoint blade")**\
        

5.  Click on **Choose a public IP address**, and select the
    **WebAPPLBIP** IP Address in the **ContosoExistingRG** resource
    group.
    
    ![In the Add endpoint blade, Target resource, which is selected to
    WebAPPLBIP, is selected. In the Resource blade, WebAPPLBIP
    (ContosoExistingRG) is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image55.png "Add endpoint and Resource blades")

6.  Set **Regional grouping** to **All (World)** so this endpoint will
    load balanced against all traffic going to Traffic Manager for now.\
    ![In the Add endpoint blade, the Regional grouping field is set to
    All (World). The remaining fields are set to the following settings:
    Type, Azure endpoint; Name, External Load Balancer; Target resource
    type, Public IP address; Target resource,
    WebAPPLBIP.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image56.png "Add endpoint blade")

7.  Click **OK**.

8.  Click on **Overview**, and select the **DNS Name** for the Traffic
    Manager to navigate to the sample application in a new browser
    window

    ![In the left pane of the contosowebapp blade, Overview is selected.
    In the right pane, under Essentials, DNS name
    contosowebapp.trafficmanager.net is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image57.png "contosowebapp blade")

9.  The sample application loading will indicate the **Traffic Manager**
    was configured correctly.
    
    ![The Contoso Financial login webpage
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image58.png "Contoso Financial login webpage")

## Exercise 3: Setup API Tier in Azure App Service

In the migration of IaaS to PaaS, the API Tier of Contoso Financials
application needs to be migrated to run in an Azure App Service Web App
without requiring any code changes to the application.

#### Help references

|         |            |
| ------------- |:-------------:|
| API Apps overview    | <https://docs.microsoft.com/en-us/azure/app-service-api/app-service-api-apps-why-best-platform> |
| Deploy an ASP.NET web app to Azure App Service, using Visual Studio  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/>  |
| Configure web apps in Azure App Service  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-configure/>  |



#### Step 1: Create App Service for Web API Tier

1.  From the Azure Management portal <http://portal.azure.com>, using a
    new tab or instance, click on **+New**, and type **API App** into
    the search box, and press **Enter**.

    ![In the left menu of the Azure Portal, New is selected. In the New
    pane, the search field is set to API
    App.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image59.png "Azure Portal")

2.  Click on **API App** in the search results, and click **Create**.

    ![In the Search Results, API app is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image60.png "Search Results")

3.  On the **API App** blade, enter the following values:

    -   App name: **enter a unique name**

    -   Resource group: **Create New -** **OptimizedAPIRG**

    -   App Insights: **Off**
       
        ![Fields in the API App blade are set to the previously defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image61.png "API App blade")

4.  Click on **App Service plan/Location**, followed by **Create New**,
    and fill in the following values:

    -   App Service plan: **OptimizedAPIPlan**

    -   Location: **North Central US**

    -   Pricing tier: **S1 Standard\
        
        ![In the API App blade,App Service plan/Location is selected.
        , In the App Service plan blade, Create New is selected. In the
        New App Service Plan blade, fields are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image62.png "API App, App Service plan, and New App Service Plan blades")

5.  Click **OK**.

6.  Click **Create**.

#### Step 2: Setup App Settings

1.  Click on **Resource groups**, select the **ContosoExistingRG**
    resource group, and click on the **contosofinancialdb** SQL
    Database.
    
    ![In the Azure Portal, in the left menu, Resource groups is
    selected. In the Resource groups blade, under Subscriptions,
    ContosoExistingRG is selected. In the ContosoExistingRG blade,
    Overview is selected, and under Essentials, the SQL database
    contosofinancialdb is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image63.png "Azure Portal")

2.  On the **SQL database** blade, click on **Show database connection    strings**.
  
    ![In the left pane of the SQL database blade, Overview is
    selected. In the right pane, under Essentials, the Connection
    strings link Show database connection strings is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image64.png "SQL database blade")

3.  On the **Database connection strings** blade, copy the **ADO.NET
    (SQL authentication)** connection string to use later.
    
    ![In the Database connection strings blade, the ADO.NET (SQL
    authentication) connection string is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image65.png "Database connection strings blade")

4.  Click on **Resource groups**, click on the **OptimizedAPIRG**
    resource group, and then, click on the previously created **API    App**.
    
    ![In the Azure Portal left menu, Resource groups is selected. In the
    Resource groups blade, under Subscriptions, OptimizedAPIRG is
    selected. In the OptimizedAPIRG blade, Overview is selected, and in
    the Essentials section, the contosofinancialapi App Service is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image66.png "Azure Portal")

5.  On the **App Service** blade, click on **Application settings**.
    
    ![In the App Service blade, under Settings, Application settings
    is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image67.png "App Service blade")

6.  Scroll down to the **Connection strings** section, and add a **new**
    connection string with the following values:

    -   Name: **TransactionDb**

    -   Value: **paste in the database connection string that was copied
        earlier**

    -   Type: **SQL Database**

    ![In the Application settings blade, fields in the Connection strings
    are set to the previously defined
    settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image68.png "Application settings blade")

7.  Replace the value **{your\_username}** with **demouser** in the
    connection string.

8.  Replace the value **{your\_password}** with **demo@pass123** in the
    connection string.

9.  Click **Save**.

#### Step 3: Deploy API to App Service

1.  From the *C:\\HOL\\Contoso.Financial* folder, open the Visual Studio
    Solution: **Contoso.Financial.sln**.

2.  In the **Solution Explorer** window, expand the **API** folder,
    right-click the **Contoso.Financial.Api**, and click on
    **Publish...**

    ![In Solution Explorer, under API, Contoso.Financial.Api is
    selected, and from it\'s right-click menu, Publish is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image69.png "Solution Explorer")

3.  On the **Publish** window, click on **Microsoft Azure App Service**,
    check the **Select Existing** option, and click **Publish**.

    ![In the Publish window, Microsoft Azure App Service, Select
    Existing, and Publish are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image70.png "Publish window")

4.  In the top-right corner of the **App Service** dialog, make sure
    your account is selected. If it is not, click on the button, and add
    it.

    ![Screenshot of the Microsoft account
    button.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image71.png "Microsoft account button")

5.  Expand the **OptimizedAPIRG** resource group, select the **App
    Service Web App**, and click **OK**.
    
    ![In the App Service window, the OptimizedAPIRG folder is expanded,
    and Contosofinancial.api is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image72.png "App Service window")

6.  Once the deployment has completed, Visual Studio will automatically
    open a new browser window navigating to the **App Service** app.
    This window can be closed.
    
    ![The Transaction API webpage
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image74.png "Transaction API webpage")



## Exercise 4: Migrate Web App Tier to App Service

In the migration of IaaS to PaaS, the Front-end Web App Tier of Contoso
Financials application needs to be migrated to run in an Azure App
Service Web App without requiring any code changes to the application.

#### Help references

|         |            |
| ------------- |:-------------:|
| Azure Web Apps overview  | <https://docs.microsoft.com/en-us/azure/app-service-api/app-service-api-apps-why-best-platform> |
| Deploy an ASP.NET web app to Azure App Service, using Visual Studio  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/>  |
| Configure web apps in Azure App Service  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-configure/>  |



#### Step 1: Create App Service for Web App Tier

1.  From the Azure Management portal <http://portal.azure.com>, using a
    new tab or instance, click on **+New**, then **Web + Mobile**, and
    then click on **Web App**.

    ![In the Azure Portal left menu, New is selected. In the New pane,
    under Azure Marketplace, Web + Mobile is selected. Under Featured,
    the Web App Quickstart tutorial link is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image75.png "Azure Portal")

2.  On the **Web App** blade, enter the following values:

    -   App name: **enter a unique name**

    -   Resource Group: **Create New - OptimizedWebAppRG**

    -   App Insights: **Off**
       
      ![Fields in the Web App blade are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image76.png "Web App blade")
        

3.  Click on **App Service plan/Location**, then **Create New**, and
    fill in the following values:

    -   App Service plan: **OptimizedWebAppPlan**

    -   Location: **North Central US**

    -   Pricing tier: **S1 Standard**
        

    ![In the Web App blade, App Service plan/Location is selected. In the
    App Service plan blade, Create New is selected, and fields are set to
    the previously defined
    settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image77.png "Web App, and App Service plan blades")

4.  Click **OK**.

5.  Click **Create**.

#### Step 2: Setup App Settings

1.  Click on **Resource groups**, click on the **OptimizedWebAppRG**
    resource group, then click on the **Web App**.

    ![In the Azure Portal left menu, Resource groups is selected. In the
    Resource groups blade, OptimizedWebAppRG is selected. In the
    OptimizedWebAppRG blade, Overview is selected, and under Essentials,
    the contosofinancialwebapp app service is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image78.png "Azure Portal")

2.  On the **Web App** blade, click on **Application settings**

    ![In the App Service blade, under Settings, Application settings
    is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image79.png "App Service blade")

3.  Scroll down to the **App settings** section, and create a **new**
    app setting with the following values:

    -   Key: **transactionAPIUrl**

4.  Value: **paste in the URL of the App Service API App that is hosting
    the API Tier**.

    ![In the App Service blade, under App settings are set to
    transactionAPIUrl, and
    http://contosofinancialapi\...](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image80.png "App Service blade")

5.  Click **Save**.

#### Step 3: Deploy App to Web App

1.  From the *C:\\HOL\\Contoso.Financial* folder, open the Visual Studio
    Solution: **Contoso.Financial.sln**.

2.  In the **Solution Explorer** window, expand the **Web** folder,
    right-click the **Contoso.Financial.Website** project, and click on
    **Publish...**

    ![In Solution Explorer, Web is expanded, Contoso.Financial.Website
    is selected, and Publish is selected from its right-click
    menu.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image81.png "Solution Explorer")

3.  On the **Publish** window, click on **Microsoft Azure App Service**,
    check the **Select Existing** option, and click **Publish**.

    ![In the Publish window, Microsoft Azure App Service, Select
    Existing, and Publish are all
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image70.png "Publish window")

4.  In the top-right corner of the **App Service** dialog, make sure
    your account is selected. If it is not, click on the button, and add
    it.

    ![Screenshot of the Microsoft account
    button.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image71.png "Microsoft account button")

5.  Expand the **OptimizedWebAppRG** resource group, select the **Web
    App**, and click **OK**.

    ![In the App Service window, OptimizedWebAppRG is expanded, and
    contosofinancialwebapp is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image82.png "App Service window")

6.  Once the deployment has completed, Visual Studio will automatically
    open a new browser window navigating to the **Web App**.

#### Step 4: Add Web App to Traffic Manager

1.  From the Azure Management portal <http://portal.azure.com>, using a
    new tab or instance, click on **Resource groups** followed by the
    **OptimizedTFRG** resource group, and then, click on the **Traffic    Manager**.\
    \
    ![In the left menu of the Azure Portal, Resource groups is selected.
    In the Resource groups blade, under Subscriptions, OptimizedTFRG is
    selected. In the OptimizedTFRG blade, Overview is selected, and
    under Essentials, the contosowebapp Traffic Manager is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image83.png "Azure Portal")

2.  On the **Traffic Manager profile** blade, click on **Endpoints**.
    
    ![Screenshot of the Endpoints
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image84.png "Endpoints option")

3.  Click **Add**.

    ![In the contosowebapp - Endpoints blade, the Add button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image85.png "contosowebapp - Endpoints blade")

4.  On the **Add endpoint** blade, enter the following values:

    -   Type: **Azure endpoint**

    -   Name: **Web App**

    -   Target resource type: **App Service**

    ![Fields in the Add endpoint blade are set to the previously defined
    settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image86.png "Add endpoint blade")


5.  Click on **Choose an app service**.

    ![Screenshot of the Choose an app service
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image87.png "Choose an app service option")

5.  Click on the previously created **Web App**.

    ![In the Resource blade, contosofinancialwebapp is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image88.png "Resource blade")

7.  Set **Regional grouping** to **North America / Central America /
    Caribbean**.

    ![Under contosofinancialwebapp, Regional grouping is set to North
    America / Central America /
    Caribbean.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image89.png "contosofinancialwebapp section")

    > If you are geographically located outside of the "North America /
    Central America / Caribbean" region specified, then choose the next
    closest region to where you are located. It is important that you choose
    a "Regional grouping" here that matches where you are located so you can
    run and test the rest of this HOL.

8.  Click **OK**.

9.  Click on the **External Load Balancer** Endpoint.

    ![Under Name, External Load Balancer is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image90.png "External Load Balancer option")

10. Select the **Disabled Status**, and click **Save**.

    ![In the External Load Balancer blade, Status is set to Disabled,
    and Save is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image91.png "External Load Balancer blade")

11. On the **Traffic Manager**, click on **Overview**.

    ![In the contosowebapp blade, Overview is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image92.png "contosowebapp blade")

12. Click on the **DNS name** to open it in a new browser window.

    ![In the contosowebapp blade, under Essentials, the DNS name
    contosowebapp.trafficmanager.net link is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image93.png "contosowebapp blade")

13. Verify the site still loads as expected.

    ![The Contoso Financial login webpage
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image94.png "Contoso Financial login webpage")

14. Click on **Endpoints**.

    ![Under Settings, Endpoints is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image95.png "Settings section")

15. Click on the **External Load Balancer** endpoint.

    ![Under Name, the External Load Balancer option is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image90.png "External Load Balancer option")

16. Click **Delete**.

    ![The Delete button is selected in the External Load Balancer
    blade.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image96.png "External Load Balancer blade")

17. On the **Delete Traffic Manager endpoint** prompt, click **Yes**.

    ![In the External Load Balancer blade, a message displays confirming
    that you want to delete the traffic manager endpoint, and the Yes
    button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image97.png "External Load Balancer blade")

    > Following this step, the Web App Tier's Load Balancer and VMs will no
    longer receive requests through the Traffic Manager.

#### Step 5: Take down Web App and API VMs

1.  Click on **Resource groups**, and then click on the
    **ContosoExistingRG** resource group.

2.  Click on the **WebApp1** virtual machine.

3.  Click the **Stop** button.

    ![In the left pane of the WebAPI1 blade, Overview is selected. In
    the right pane, on the top menu, the Stop button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image98.png "WebAPI1 blade")

4.  On the **Stop this virtual machine** prompt, click **Yes**.

    ![In the Stop this virtual machine prompt, a confirmation message
    displays asking if you want to stop WebAPI1, and the Yes button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image99.png "Stop this virtual machine prompt")

5.  Repeat the last three steps for the **WebApp2, WebAPI1,** and
    **WebAPI2** virtual machines.

6.  Open a new browser window / tab, and navigate to the URL for the
    **Traffic Manager endpoint**.

7.  **Login** to the Web App, and ensure it loads all data as expected
    to test out the **App Service** hosted Web App and API tiers are
    functioning properly. FYI, the password can be anything, just type
    something in the password and click Sign in to login to the sample
    app.\
    \
    ![The Account Overview webpage displays with an available balance
    and a list of account
    transactions.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image100.png "Account Overview webpage")

8.  After validating the app, close the browser window.

## Exercise 5: Migrate Background Tier to App Service

In the migration of IaaS to PaaS, the Background Tier (written as a
console app) of Contoso Financials application needs to be migrated to
run in an Azure App Service Web Job without requiring any code changes
to the application.

#### Help references

|         |            |
| ------------- |:-------------:|
| Using WebJobs in Azure App Service  | <https://azure.microsoft.com/en-us/documentation/articles/app-service-webjobs-readme/> |
| Run Background tasks with WebJobs  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-create-web-jobs/>  |
| Configure web apps in Azure App Service  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-configure/>  |



#### Step 1: Create App Service for Background Tier

1.  From the Azure Management portal <http://portal.azure.com>, using a
    new tab or instance, click on **+New** followed by **Web + Mobile**,
    and then, click on **Web App**.

    ![New is selected in the left menu of the Azure Portal. In the New
    pane, under Azure Marketplace, Web + Mobile is selected, and under
    Featured, the Web App Quickstart tutorial link is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image75.png "Azure Portal")

2.  On the **Web App** blade, enter the following values:

    -   App name: **enter a unique name**

    -   Resource Group: **OptimizedBackgroundRG**

    -   App Insights: **Off**

        ![The Web App blade fields are set to the previously defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image101.png "Web App blade")

3.  Click on **App Service plan/Location**, select **Create New**, and
    fill in the following values:

    -   App Service plan: **OptimizedBackgroundPlan**

    -   Location: **North Central US**

    -   Pricing tier: **S1 Standard**
    -   
        ![In the Web App blade, App Service plan OptimizedBackgroundPlan
        is selected. In the App Service plan blade, Create New is
        selected, and fields are set to the previously defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image102.png "Web App and App Service plan blades")

4.  Click **OK**.

5.  Click **Create**.

#### Step 2: Setup App Settings

1.  Click on **Resource groups**, select the **OptimizedBackgroundRG**
    resource group, and select the **App Service**.
    
    ![In the left menu of the Azure Portal, Resource groups is selected.
    In the Resource groups blade, OptimizedBackgroundRG is selected. In
    the OptimizedBackgroundRG blade, Overview is selected, and in the
    Essentials section, the contosofinancialbackground App Service is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image103.png "Azure Portal")

2.  On the **Web app** blade, click on **Application settings**.
    
    ![In the contosofinancialbackground blade, under Settings,
    Application settings is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image104.png "contosofinancialbackground blade")

3.  Scroll down to the **Connection strings** section, and add a **new**
    connection string with the following values:

    -   Name: **TransactionDb**

    -   Value: **past in the database connection string that was copied
        earlier**

    -   Type: **SQL Database**

    ![In the contosofinancialbackground - Application settings blade,
    Connection strings values are set to the previously defined
    settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image105.png "contosofinancialbackground - Application settings blade")

4.  Replace the value **{your\_username}** with **demouser** in the
    connection string.

5.  Replace the value **{your\_password}** with **demo@pass123** in the
    connection string.

6.  Click **Save**.

#### Step 3: Deploy App to App Service

1.  From the *C:\\HOL\\Contoso.Financial* folder, open the Visual Studio
    Solution: **Contoso.Financial.sln**

2.  In the **Solution Explorer** window, expand the **Background**
    folder, and right-click the **Contoso.Financial.Background** project
    followed by clicking on **Publish as Azure WebJob...**
    
    ![In Solution Explorer, the Background folder is expanded, and
    Contoso.Financial.Background is selected. From its right-click menu,
    Publish as Azure WebJob is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image106.png "Solution Explorer")

3.  On the **Add Azure WebJob** dialog, enter the following values:

    -   WebJob name: **Background1**

    -   WebJob run mode: **Run on Demand**
       
        ![In the Add Azure WebJob window, fields are set to the
        previously defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image107.png "Add Azure WebJob window")

4.  Click **OK**.

5.  On the **Publish** dialog, click on **Microsoft Azure App Service**.
.  
    ![In the Publish window, under Select a publish target, Microsoft
    Azure App Service is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image108.png "Publish window")

6.  In the top-right corner of the **App Service** dialog, make sure
    your account is selected. If it is not, click on the button, and add
    it.

    ![Screenshot of the Microsoft account
    button.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image71.png "Microsoft account button")

7.  Expand the **OptimizedBackgroundRG** resource group, and select the
    **App Service Web App**, followed by clicking **OK**.
    
    ![In the App Service window, the OptimizedBackgroundRG folder is
    expanded, and contosofinancialbackground is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image109.png "App Service window")

8.  Click **Publish**.

    ![In the Publish window, the Publish button is
    selected.]>(images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image110.png "Publish window")

    > If the WebJob deployment fails due to a code signing error message,
    simply open up the **Project Properties** for the
    Contoso.Financial.Background project by right-clicking it in **Solution
    Explorer**. Then, go to the **Signing** tab, and **uncheck** the **Sign
    the ClickOnce manifests** checkbox. Upon completion, Publish the WebJob
    project again.

    ![In Solution Explorer, Background and Contoso.Financial.Background are
    expanded, and Properties is selected. In the ContosoFinancialBackground
    Properties pane, Signing is selected, and the checkbox is cleared for
    Sign the ClickOnce
    manifests.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image111.png "Solution Explorer")

9.  Navigate to the **contosofinancialbackground** Web App in the Azure
    Portal, click on the **WebJobs** pane. Then, click on the
    **Background1** WebJob, and select **Properties**

    ![In the contosofinancialbackground - WebJobs blade, in the left
    pane, WebJobs is selected. In the right pane, under WebJobs,
    Background1 is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image112.png "contosofinancialbackground - WebJobs blade")

10. Copy the **Web Hook URL, User Name, and Password**. Save these
    properties for setting up the Scheduler next.

    ![In the Properties blade, the following fields are defined: Name,
    Background1; Status, Ready; Type, triggered; Web Hook,
    https://contosofinancialbackground.sc\...; User Name,
    \$contosofinancialbackground; Password
    (hidden).](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image113.png "Properties blade")

11. From the Azure Portal, click on **+New**, and type "**scheduler**"
    into the search box. Press **Enter**.

    ![In the left menu of the Azure Portal, the New button is selected.
    In the New blade, scheduler is typed in the search
    field.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image114.png "Azure Portal")

12. Select **Scheduler** from the search results, and click **Create**.

    ![In the Results section, Scheduler is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image115.png "Results section")

13. On the **Scheduler Job** blade, enter the following values:

    -   Name: **Background-Scheduler**\
        ![In the Scheduler Job blade, under Create, the Name field is
        set to
        Background-Scheduler.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image116.png "Scheduler Job blade")

14. Click on **Job Collection**, click on **Create new**, enter the
    following values, and click **OK**.

    -   Name: **Background-Scheduler-Job**

    -   Resource Group: **select the existing
        OptimizedBackgroundRG**.**\
        **![In the New job collection blade, Name is set to
        Background-Scheduler-Job, Pricing tier is S Standard, Resource
        group is Use existing OptimizedBackgroundRG, and Location is
        South Central
        US.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image117.png "New job collection blade")

15. Click on **Configure Action settings**

    ![Screenshot of the Configure Action Settings
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image118.png "Configure Action Settings option")

16. On the **Action settings** pane, enter the **Web Hook URL** copied
    earlier to the **URL** field, set the **Action** to **Https**, and
    set the **Method** equal to **Post**.

    ![In the Action settings blade, Action is set to Https, Method is
    set to Post, and the URL is the previously copied Web Hook
    URL.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image119.png "Action settings blade")

17. Click on **Authentication settings**.

    ![Under Optional settings, Authentication settings is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image120.png "Authentication settings option")

18. Enter the following values, and click **OK**.

    -   Authenication type: **Basic**

    -   Username: **Webhook username copied earlier**

    -   Password: **Webhook password copied earlier**

        ![Fields in the Authentication blade are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image121.png "Authentication blade")

19. Click **OK** then click **OK** again.

20. Click on **Configure Schedule**.

    ![Screenshot of the Configure Schedule
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image122.png "Configure Schedule option")

21. Select **Recurring**, and specify Recur every **1 minute** followed
    by clicking **OK**.

    ![In the Schedule blade, fields are set to the previously defined
    settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image123.png "Schedule blade")

22. Click **Ok** and then click **Create**.

23. Wait a couple minutes, and then, look at the **History** tile of the
    **Scheduler Job** blade to verify the scheduled job is running. The
    **bar graph** and **successes count** will reflect that it is
    running.
    
    ![In the Monitoring section, a History bar graph displays, with 6
    successes, 0 required retries, and 0
    failures.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image124.png "Monitoring section")

24. Open a new browser window or tab navigating to the **URL** for the
    **Traffic Manager** for the application, and verify the transactions
    generated by the background process are showing up.
    
    ![The Account Overview webpage displays with an available balance
    and a list of account
    transactions.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image125.png "Account Overview webpage")

#### Step 4: Take down Background Tier VM

1.  From the Azure Management Portal (<http://portal.azure.com>), click
    on **Resource groups**, and then, click on the **ContosoExistingRG**
    resource group.
    
    ![In the left pane of the Azure Portal, Resource groups is selected.
    In the Resource groups pane, under Subscriptions, ContosoExistingRG
    is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image126.png "Azure Portal")

2.  Click on the **Background1** virtual machine.

3.  Click the **Stop** button.

    ![In the left pane of the Background1 blade, Overview is selected.
    In the right pane, the Stop button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image127.png "Background1 blade")

4.  On the **Stop this virtual machine** prompt, click **Yes**.

    ![In the Stop this virtual machine prompt, a confirmation message
    displays asking if you want to stop Background1, and the Yes button
    is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image128.png "Stop this virtual machine prompt")

## Exercise 6: Setup SQL Database Geo-Replication

Due to the rush into Production, the Staging SQL Database currently
remains as the Production database for the application. You have been
asked to implement Geo-Replication to the SQL Database in order to add
the appropriate redundancy to safeguard against failures. This will both
help eliminate data loss in case of a data center failure as well as
greatly reduce the potential system downtime in the event of such a
failure.

#### Help references

|         |            |
| ------------- |:-------------:|
| Introduction to SQL Database  | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-technical-overview/> |
| SQL Database Active Geo-Replication  | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-geo-replication-overview/>  |


#### Step 1: Setup SQL Database Geo-Replication

1.  Click on **Resource groups**, click on the **ContosoExistingRG**
    resource group followed by clicking on the **contosofinancialdb**
    SQL Database.
    
    ![In the Azure Portal left menu, Resource groups is selected. In the
    Resource groups pane, under Subscriptions, ContosoExistingRG is
    selected. In the ContosoExistingRG blade, both Overview and the
    contosofinancialdb SQL database are selected
    ](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image129.png "Azure Portal")

2.  On the **SQL database** blade, click on **Geo-Replication**.
    
    ![In the Contosofinancialdb blade, under Settings, Geo-Replication
    is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image130.png "Contosofinancialdb blade")

3.  Click on the **Recommended Target Region** to replicate to.
    
    ![In the Contosofinancialdb - Geo-Replication blade, under Target
    Regions, South Central US is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image131.png "Contosofinancialdb - Geo-Replication blade")

4.  On the **Create secondary** blade, click on **Target server**.
  
    ![In the Create Secondary blade, Target server is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image132.png "Create Secondary blade")

5.  On the **New server** blade, enter the following values:

    -   Server name: **enter a unique name**

    -   Server admin login: **demouser**

    -   Password: **demo@pass123**
        
        ![Fields in the New server blade are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image133.png "New server blade")

6.  Click **Select**.

7.  Click **OK**.

8.  Database replication is now configured.
    
    ![The Contosofinancialdb - Geo-Replication blade displays, with the
    Primary Server set to North Central US, and the Secondaries set to
    South Central
    US.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image134.png "Contosofinancialdb - Geo-Replication blade")


## Exercise 7: Take down old architecture / resources

Since the Contoso Financial application has now been migrated to Azure
PaaS services utilizing Azure App Service, the older, existing
architecture no longer being used needs to be removed. Since the
application has been validated to work as expected, you have been asked
to delete the Azure IaaS components hosting the VM infrastructure.

#### Step 1: Remove Old VM-based tiers

1.  Click on **Resource groups**, and then click on the
    **ContosoExistingRG** resource group.

2.  Delete the following resources that are hosting the OLD Web App,
    API, and Background tiers.

    -   **BackgroundAV**

    -   **WebAPIAV**

    -   **Background1**

    -   **WebAPI1**

    -   **WebAPI2**

    -   **WebApp1**

    -   **WebApp2**

    -   **WebAPILB**

    -   **WebAppLB**

    -   **background1nic**

    -   **webapi1nic**

    -   **webapi2nic**

    -   **webapp1nic**

    -   **webapp2nic**

    -   **Background1-ip**

    -   **WebAPI1-ip**

    -   **WebAPI2-ip**

    -   **WebApp1-ip**

    -   **WebApp2-ip**

    -   **WebAPPLBIP**

    -   **AppVNET**

    -   **Background1-nsg**

    -   **WebAPI1-nsg**

    -   **WebApp1-nsg**
    
        ![In the Azure Portal left menu, Resource groups is selected. In
        the Resource grups blade, ContosoExistingRG is selected. In the
        ContosoExistingRG blade, Overview is selected, and all names
        under the list of resources are
        selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image135.png "Azure Portal")

    > Be sure not to delete the Azure SQL Database (**contosofinancialdb**)
and Azure SQL Server. These are still in use!

3.  Delete the **Storage Accounts** with the following name prefixes:

    -   **diag**

    -   **disk**
       
        ![The two previously listed Storage Accounts
        display.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image136.png "Storage Accounts")

4.  Once all of the resources for the VMs that are no longer needed have
    been deleted / removed from the **ContosoExistingRG** resource
    group, the only resources left in that resource group should be the
    **SQL Databases and Servers**.\
    \
    ![In the left pane of the ContosoExistingRG blade, Overview is
    selected. In the top menu, the Refresh button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image137.png "ContosoExistingRG blade")

## Exercise 8: Setup European Web App Tier Instance

As Contoso Financial expands into Europe, they need to handle the
additional growth while maintaining the same application performance.
While to fully support global scale, there are pieces of the application
that will need to be refactored, as you have been asked to setup a
secondary region for the Front-end Web App Tier in the Azure North
Europe region.

#### Help references

|         |            |
| ------------- |:-------------:|
| Azure Web Apps overview | <https://azure.microsoft.com/en-us/documentation/articles/app-service-web-overview/> |
| Deploy an ASP.NET web app to Azure App Service, using Visual Studio  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/>  |
| Configure web apps in Azure App Service  | <https://azure.microsoft.com/en-us/documentation/articles/web-sites-configure/>  |


#### Step 1: Create European App Service

1.  From the Azure Management portal: <http://portal.azure.com>, using a
    new tab or instance, click on **+New**, then **Web + Mobile**, and
    then click on **Web App**.
    
    ![New is selected in the Azure Portal left pane. In the New blade,
    under Azure Marketplace, Web + Mobile is selected, and under
    Featured, the Web App quickstart tutorial is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image75.png "Azure Portal")

2.  On the **Web App** blade, enter the following values:

    -   App name: **enter a unique name**

    -   Resource Group: **OptimizedWebAppEuropeRG**

    -   App Insights: **Off\
        \
        **![Fields in the Web App blade are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image138.png "Web App blade")**\
        **

3.  Click on **App Service plan/Location**, then **Create New**, and
    fill in the following values:

    -   App Service Plan: **OptimizedWebAppEuropePlan**

    -   Location: **North Europe**

    -   Pricing tier: **S1 Standard**
        
        ![Fields in the App Service plan blade are set to the previously
        defined
        settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image139.png "App Service plan blade")

4.  Click **OK**.

5.  Click **Create**.

#### Step 2: Set App Settings

1.  Click on **Resource groups**, and select the
    **OptimizedWebAppEuropeRG** resource group. Then, click on the **Web    App**.
    
    ![In the Azure Portal left menu, Resource groups is selected. In the
    Resource groups pane, under Subscriptions, OptimizedWebAppEuropeRG
    is selected. In the OptimizedWebAppEuropeRG blade, both Overview and
    the contosofinancialwebappeuro App Service are selected
    ](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image140.png "Azure Portal")

2.  On the **Web App** blade, click on **Application settings**.**\
    \
    **![In the Web App blade, under Settings, Application settings is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image141.png "Web App blade")**\
    **

3.  Scroll down to the **App settings** section, and create a **new**
    app setting with the following values:

    -   Key: **transactionAPIUrl**

    -   Value: **paste in the URL of the App Service Web App that is
        hosting the API tier. This should be set to the same value used
        for the Web App Tier in the North Central US region.**

    > ![In the contosofinancialwebappeuro blade, under Settings, Application
    > settings is selected. Under App settings, fields are set to the
    > previously defined
    > settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image142.png "contosofinancialwebappeuro blade")

4.  Click **Save**.

#### Step 3: Deploy Web App to European Region

1.  From the *C:\\HOL\\Contoso.Financial* folder, open the Visual Studio
    Solution: **Contoso.Financial.sln**.

2.  In the **Solution Explorer** window, expand the **Web** folder, then
    right-click the **Contoso.Financial.Website** project, and click on
    **Publish...**
    
    ![In Solution Explorer, the Web folder is expanded, and
    Contoso.Financial.Website is selected. From its right-click menu,
    Publish is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image143.png "Solution Explorer")

3.  Click the **Create new profile** link.

    ![In the Publish window, the Create new profile link is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image144.png "Publish window")

4.  On the **Pick a publish target** dialog, click on **Microsoft Azure
    App Service**, and choose **Select Existing**, Then, click **OK**.

    ![In the Pick a publish target window, Microsoft Azure App Service,
    Select Existing, and the OK button are all
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image145.png "Pick a publish target window")

5.  On the **App Service** dialog, expand the
    **OptimizedWebAppEuropeRG** resource group, select the **Web App**
    in the North Europe region, and then, click **OK**.

    ![In the App Service dialog box, the OptimizedWebAppEuropeRG folder
    is expanded, and contosofinancialwebappeuro is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image146.png "App Service dialog box")

6.  Select the Deployment Profile for the European instance, and click
    **Publish**.
    
    ![In the Publish window, contosofinancialwebappeuro - Web Deploy is
    set as the deployment profile, and the Publish button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image147.png "Publish window")

7.  Once the deployment has completed, Visual Studio will automatically
    open a new browser window navigating to the **Web App**.
    
    ![The Contoso Financial login page
    displays.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image148.png "Contoso Financial login page")

#### Step 4: Add European Region to Traffic Manager

1.  From the Azure Management Portal <http://portal.azure.com>, using a
    new tab or instance, click on **Resource groups**, click on the
    **OptimizedTFRG** resource group, then click on the **Traffic    Manager**.

    ![In the Azure Portal left menu, Resource groups is selected. In the
    Resource groups pane, under Subscriptions, OptimizedTFRG is
    selected. In the OptimizedTFRG blade, both Overview and the
    contosowebapp Traffic Manager are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image83.png "Azure Portal")

2.  On the **Traffic Manager profile** blade, click on **Endpoints**.
  
    ![Screenshot of the Endpoints
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image149.png "Endpoints option")

3.  Click **Add**.
    
    ![On the contosowebapp - Endpoints blade menu, the Add button is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image150.png "contosowebapp - Endpoints blade")

4.  On the **Add endpoint** blade, enter the following values:

    -   Type: **Azure endpoint**

    -   Name: **Web App (Europe)**

    -   Target resource type: **App Service**

    ![Fields in the Add endpoint blade are set to the previously defined
    settings.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image151.png "Add endpoint blade")

5.  Click on **Choose an app service**.

    ![Screenshot of the Choose an app service
    option.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image87.png "Choose an app service option")

6.  Click on the **Web App** created in the **North Europe** region.
    
    ![On the Resource blade, contosofinancialwebappeuro is
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image152.png "Resource blade")

7.  Set the **Regional grouping** to **Europe**.

    ![Under Geo-mapping, Regional grouping is set to
    Europe.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image153.png "Geo-mapping section")

8.  Click **OK**.

9.  Click on **Overview**.
    
    ![Overview is selected in the contosowebapp - Endpoints
    blade.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image154.png "contosowebapp - Endpoints blade")

10. On the **Traffic Manager profile** blade, click on the **DNS name**
    to open a new browser window navigating to the **Traffic Manager**
    endpoint.
    
    ![In the Traffic Manager profile blade, Overview, and the DNS name
    contosowebapp.trafficmanager.net link are
    selected.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image155.png "Traffic Manager profile blade")

11. Login to the Web App and ensure it loads all data as expected to
    test out the App Service hosted Web App and API App tiers are
    functioning properly.
    
    ![The Contoso Financial Account Overview webpage displays with
    Transaction details in an account transaction
    ledger.](images/Hands-onlabstep-by-step-Optimizedarchitectureimages/media/image100.png "Contoso Financial Account Overview webpage")

12.  After validating the app, close the browser window.

####  

## After the hands-on lab 

#### Task 1: Delete Resources

1.  Now that the HOL is complete, go ahead and delete all of the
    Resource Groups created for this HOL. You will no longer need those
    resources, and it will be beneficial to clean up your Azure
    Subscription.

You should follow all steps provided *after* attending the HOL.



