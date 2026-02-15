# About me 
### Full name: Anani Thierry Kassa
### Student ID: 041140713

1.	Create an Azure Machine Learning workspace in the Canada Central region. Once created, become familiar with the interface, including how to access designer as well as create and attach compute to work with a pipeline.
![alt text](1.PNG)
![alt text](1-1.PNG)

2.	Explore the Azure Machine Learning studio which is a web-based portal that can be accessed through azure machine learning workspace.
- Authoring section, 
- Assets section, 
- Note the Manage section
![alt text](2.PNG)
3.	Create a training pipeline – Train the model using designer
![alt text](3.PNG)
4.	Select the Regression - Automobile Price Prediction (Basic) sample 
![alt text](3-4.PNG)
5.	Select Configure & Submit (5-6 share the same screenshot)
6.	Create new experiment and set the name as train-regression-designer-ml
![alt text](6.PNG)
7.	On the Inputs & outputs page select Next without making any changes
![alt text](7.PNG)
8.	On the Runtime settings page an error appears as you don´t a default compute to run the pipeline, to avoid this error create a compute instance target
![alt text](8.PNG)
9.	Create a new azure ml compute instance – select Standard_DS11_v2 from the recommended option.
![alt text](9.PNG)
10.	Create and wait for the instance to start until it’s running.(10-11 share the same screenshot)
11.	Execute your training pipeline
![alt text](10.PNG)
12.	Use jobs tab to review your workload and see the status of the pipeline if it has executed successfully or failed.
![alt text](12.PNG)
13.	When the job is completed, view the details of each individual component run, including the output. Explore the pipeline to understand how the model is trained.
![alt text](13-1.PNG)
![alt text](13-2.PNG)
![alt text](13-3.PNG)
![alt text](13-4.PNG)
![alt text](13-5.PNG)
![alt text](13.PNG)
![alt text](13-6.PNG)
14.	Delete all the resources created in the lab.
![alt text](14.PNG)

