# About me 
### Full name: Anani Thierry Kassa
### Student ID: 041140713

### Task 1: Create an Azure Policy – Allowed Locations
Purpose: Ensure resources can only be deployed in an approved region.
Steps:
1.	Sign in to the Azure Portal
2.	Search for Policy
3.	Select Definitions
4.	Search for the built-in policy:
o	“Allowed locations”
![alt text](1.PNG)
5.	Select the policy → Click Assign
6.	Configure:
o	Scope: Subscription
![alt text](2.PNG)
o	Allowed locations: Canada Central
![alt text](2-1.PNG)
7.	Review + Create

Validation:
•	Attempt to create a resource in a different region (e.g., East US)
•	Confirm deployment fails
![alt text](2-2.PNG)

### Task 2: Create a Virtual Network (Canada Central)
Purpose: Establish a secure network boundary.
Steps:
1.	Search for Virtual Networks
2.	Select Create
3.	Configure:
o	Region: Canada Central
![alt text](2-3.PNG)
o	Address space: 10.0.0.0/16
![alt text](2-4.PNG)
4.	Do not add subnets yet
5.	Review + Create
![alt text](2-5.PNG)

### Task 3: Create Subnets & Enable Storage Service Endpoint
Purpose: Ensure storage traffic stays within Azure’s backbone network.
Steps:
1.	Open the Virtual Network
2.	Go to Subnets
3.	Add private-subnet
o	Enable Service Endpoint
o	Service: Microsoft.Storage
![alt text](3-1.PNG)
4.	Add public-subnet (no service endpoint)
![alt text](3-2.PNG)

### Task 4: Create Network Security Group (NSG)
Purpose: Control inbound and outbound network traffic.
Steps:
1.	Search for Network Security Groups
2.	Create NSG in Canada Central
![alt text](4-2.PNG)
3.	Associate NSG to private-subnet
![alt text](4-1.PNG)

### Task 5: Configure NSG Rules (Private Subnet)
Outbound Rule – Allow Azure Storage
•	Destination: Service Tag
•	Service Tag: Storage
•	Action: Allow
•	Priority: 100
![alt text](5-1.PNG)
Outbound Rule – Deny Internet Access
•	Destination: Internet
•	Action: Deny
•	Priority: 200
![alt text](5-2.PNG)

### Task 6: Configure NSG for Public Subnet (RDP Access)
Inbound Rule – Allow RDP
•	Source: Any
•	Port: 3389
•	Protocol: TCP
![alt text](6.PNG)

### Task 7: Create a Storage Account with File Share
Purpose: Secure storage access to only approved subnets.
Steps:
1.	Create Storage Account
o	Region: Canada Central
2.	Go to Networking
3.	Set:
o	Network access: Enabled from selected networks
o	Allow access only from private-subnet
![alt text](7-1.PNG)
4.	Create Azure File Share
![alt text](7-2.PNG)

### Task 8: Deploy Virtual Machines
Deploy two Windows VMs:
VM Name	Subnet
vm-private	private-subnet
![alt text](8-1.PNG)
vm-public	public-subnet
![alt text](8-2.PNG)
•	Enable Azure Bastion
•	Use same credentials for both VMs

### Task 9: Test Storage Access from Private Subnet (Allowed)
1.	Connect to vm-private using Bastion
2.	Open Windows PowerShell
3.	Run the following command
Expected Result:
Azure file share successfully mapped to drive Z:
![alt text](9-1.PNG)

### Task 10: Test Storage Access from Public Subnet (Denied)
1.	Connect to vm-public
2.	Repeat the same PowerShell command
Expected Result:
Access denied error
![alt text](10-1.PNG)

3. Cleanup (Mandatory)
![alt text](14.PNG)