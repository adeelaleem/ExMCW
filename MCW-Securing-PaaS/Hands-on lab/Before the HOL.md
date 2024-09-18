
![](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Securing PaaS
</div>

<div class="MCWHeader2">
Before the hands-on lab setup guide
</div>

<div class="MCWHeader3">
December 2018
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.# Securing PaaS setup

**Contents**

<!-- TOC -->

- [Securing PaaS before the hands-on lab setup guide](#securing-paas-before-the-hands-on-lab-setup-guide)
    - [Requirements](#requirements)
    - [Before the hands-on lab](#before-the-hands-on-lab)
      - [Task 1: Download GitHub resources for Jump Machine](#task-1-download-github-resources-for-jump-machine)
      - [Task 2: Deploy resources to Azure](#task-2-deploy-resources-to-azure)
      - [Task 3: Download GitHub resources for Jump machine](#task-3-download-github-resources-for-jump-machine)
      - [Task 4: Install SQL Server Management Studio](#task-4-install-sql-server-management-studio)
      - [Task 5: Install Fiddler](#task-5-install-fiddler)
      - [Task 6: Install Power BI Desktop](#task-6-install-power-bi-desktop)

<!-- /TOC -->

# Securing PaaS before the hands-on lab setup guide 

## Requirements

1.  Microsoft Azure subscription must be pay-as-you-go or MSDN

    - Trial subscriptions will *not* work.
  
2.  A machine with the following software:

    -   Visual Studio 2017 Community edition or greater
    
    -   SQL Server Management Studio 2017
    
    -   Power BI Desktop
    
    -   Fiddler

**To ensure you can begin the course delivery on-time, you must take the following step at least 5-hours prior to the course start time:**

> **Note:** The Application Service Environment (ASE) and Web Application Firewall (WAF) can take more than 90-minutes to create depending on the load in the region.

## Before the hands-on lab

Duration: 30 minutes

Synopsis: In this exercise, you will set up your environment for use in the rest of the hands-on lab. You should follow all the steps provided in the Before the Hands-on Lab section to prepare your environment *before* attending the workshop.

### Task 1: Download GitHub resources for Jump machine

In this task, you will download the Azure Resource Manager (ARM) template required to setup this lab from a GitHub repository.

1.  Open a browser window to the cloud workshop GitHub repository (<https://github.com/Microsoft/mcw-securing-paas>).

2.  Select **Clone or download**, then select **Download Zip**.

    ![In the GitHub repository window, the Clone or download button and Download Zip link are selected.](images/Setup/image3.png "GitHub repository window")

3.  Extract the zip file to your local machine, be sure to keep note of where you have extracted the files.

### Task 2: Deploy resources to Azure

In this task, you will run the ARM template downloaded in the previous task in the Azure portal to provision the resources you will be using throughout this hands-on lab.

1.  In a browser, open the [Azure Portal](https://portal.azure.com/).

    >**Note**: If prompted, select **Maybe Later**.

2.  Select **Resource groups** from the left-hand navigation menu, then select **+Add**.

    ![In the Azure Portal Resource groups pane, the Add button is selected.](images/Setup/image4.png "Azure Portal")

3.  Enter a **resource group** name, such as **paassecurity-\[your initials or first name\]**.

    ![The Resource Group blade displays.](images/Setup/image5.png "Resource Group blade")

4.  Select **Create**.

5.  Select **Refresh** to see your new resource group displayed and select it.

6.  Select **Automation Script**.

    ![The Automation Script option displays.](images/Setup/image6.png "Automation Script option")

7.  Select **Deploy**.

    ![The Deploy button displays.](images/Setup/image7.png "Deploy button")

8.  Select **Build your own template in the editor**.

9.  In the extracted folder, open the **\\Hands-on lab\\AzureTemplate\\azure-deploy.json**.

10. Copy and paste it into the window.

11. Select **Save**, you will see the dialog with the input parameters. Fill out the form:

    -   **Subscription**: Select your subscription.

    -   **Resource group**: Use an existing Resource group or create a new one by entering a unique name, such as **paassecurity-\[your initials or first name\]**.

    -   **Location**: Select a location for the Resource group. Recommend using East US, East US 2, West Central US, or West US 2.

    -   Modify the **parameters** to be something unique by replacing with your initials or something similar.

    -   Fill in the remaining parameters, but if you change anything be sure to note it for future reference throughout the lab.

    -   **Be sure your resource group location matches the location you select in the settings window**.

    >**Note**: This field and matching is due to a limitation of the resource templates not resolving the resource group location for some template types.

    ![A Dialog box displays with fields set to the previously mentioned settings. The Location, Passsecurity\_sql\_name and Location fields are all called out.](images/Setup/image8.png "Dialog box")

12. Check the **I agree to the terms and conditions stated above** checkbox.

13. Select **Purchase**.

    ![The Terms and conditions check box is selected, as is the Purchase button.](images/Setup/image9.png "Terms and conditions")

14. The deployment will take about 90 minutes to complete. To view the progress, select the **Deployments** link.

- As part of the deployment, you will see the following items created:

    - App Service Environment v2

    - Virtual Networks and Machines

    - Cosmos DB

    - Azure SQL Server and Databases

    - Application Gateway with Firewall

15. See Appendix A for detailed steps on creating these components without using an ARM template.

### Task 3: Download GitHub resources for Jump machine

In this task, you will log into the lab VM that was created by the ARM template you executed in the previous task and download the GitHub resources needed to complete this hands-on lab.

1.  Login to the paassecurity-vm-jump virtual machine.

    -   Select **Virtual machines**.

    ![The Virtual machines option is selected.](images/Setup/image10.png "Virtual machines option")

    -   Select **paassecurity-vm-jump**.

    ![The passsecurity-vm-jump option is selected.](images/Setup/image11.png "passsecurity-vm-jump option")

    -   Select **Connect**.
    
        >**Note**:  Ensure the status is **Running**.  It could take up to 10 minutes for the Virtual machine to provision.

    ![In the Virtual machine blade, Connect is selected.](images/Setup/image12.png "Virtual machine blade")

    -   Select to open the RDP connection.

    -   Enter the VM credentials (**wsadmin -- p\@ssword1rocks**).

    ![A message in the Remote Desktop Connection dialog box warns the user that the publisher of the remote connection cannot be verified, and asks if you want to continue.](images/Setup/image13.png "Remote Desktop Connection dialog box")
    
    -   Select **Connect**.

2.  Once logged in, launch the Server Manager. This should start automatically, but you can access it via the Start menu if it does not start.

3.  Select **Local Server**, if the **IE Enchanced Security Configuration** setting displays **On** then select **On**.

    ![Local Server is selected and highlighted on the left side of Server Manager, and at right, IE Enhanced Security Configuration On is highlighted under Properties For LabVM.](images/Setup/image14.png "Select IE Enhanced Security Configuration")

    -   In the Internet Explorer Enhanced Security Configuration dialog, select **Off** under Administrators, then select **OK**.

    ![Off is selected under Administrators in the Internet Explorer Enhanced Security Configuration dialog box.](images/Setup/image15.png "Disable Administrators")

5.  Close the Server Manager.

6.  Repeat the steps you completed in [Task 1](#task-1-download-github-resources-jump-machine) to download or copy the GitHub folders to the virtual machine.

### Task 4: Install SQL Server Management Studio

In this task, you will install SQL Server Management Studio (SSMS) on your Jump machine VM.

1.  On your jump machine VM, open a web browser and navigate to <https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms>.

2.  Select **Download SQL Server Management Studio 17.x**.

    ![On the SQL Server Management Studio download page, the Download SQL Server Management Studio 17.x link is highlighted.](images/Setup/image16.png "SSMS Download screen")

3.  Run the downloaded installer by clicking **Run** in the browser popup.

4.  On the Welcome screen, select **Install**.

   ![The Microsoft SQL Server Management Studio installer welcome screen is displayed, and the Install button is highlighted.](images/Setup/image17.png "Microsoft SQL Server Management Studio installer")

5.  **Close** the SSMS installer once setup is completed and **restart the VM** to complete the installation of SSMS.

### Task 5: Install Fiddler

In this task, you will download and install Fiddler, which will enable you to watch network traffic from your lab VM.

1.  In a web browser, navigate to <https://www.telerik.com/download/fiddler>.

2.  Complete the form, accepting the license agreement, and select Download for Windows.

  ![Screenshot of the Download Fiddler form.](images/Setup/image18.png "Fiddler download form")

3.  Run the download installer, accepting all the default values.

4.  Close the installer when completed.

### Task 6: Install Power BI Desktop

Below, you will install Power BI on the jump VM, which will be used in Exercise 8.

1.  In a web browser on you jump VM navigate to the Power BI Desktop download page (<https://powerbi.microsoft.com/en-us/desktop/>).

2.  Select the **Advanced Download Options** link in the middle of the page.

  ![The Power BI Desktop download screen is displayed, and Download Free is selected.](images/Setup/image19.png "Power BI Desktop download screen")

3.  Select the **Advanced Download Options** link in the middle of the page, then check the **Download** button.

4.  Select **PBIDesktop_x64.msi**, then click **Run** to start the installer.

5.  Select **Next** on the welcome screen.

  ![The Welcome screen of the Power BI installer is displayed, with the Next button highlighted and selected.](images/Setup/image20.png "Power BI Desktop installer welcome screen")

6.  Accept the license agreement, and select **Next**.

   ![Screenshot of the Power BI Desktop Software License Terms screen is displayed, with the \"I accept the terms in the License Agreement\" checkbox checked, and the Next button selected.](images/Setup/image21.png "Power BI Desktop installer license terms screen")

7.  Leave the default destination folder, and select **Next**.

  ![Screenshot of the Microsoft Power BI installer\'s Destination Folder screen, with the default path displayed, and the Next button highlighted.](images/Setup/image22.png "Power BI Desktop installer destination folder screen")

8.  Make sure the Create a desktop shortcut box is checked, and select **Install**.

   ![Screenshot of the Microsoft Power BI installer\'s Ready to Install screen, with the \"Create a desktop shortcut\" checkbox checked, and the Install button highlighted.](images/Setup/image23.png "Power BI Desktop installer ready to install screen")

9.  Uncheck **Launch Microsoft Power BI Desktop**, and select **Finish**.

   ![The Completed the Microsoft Power BI Desktop screen is displayed, with the \"Launch Microsoft Power BI Desktop\" checkbox unchecked, and the Finish button highlighted.](images/Setup/image24.png "Power BI Desktop installer complete screen")

You should follow all steps provided *before* attending the Hands-on lab.
