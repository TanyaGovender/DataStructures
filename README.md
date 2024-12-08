# Municipality Services Application

### Current version: Version 3

1. [Overview](#overview)
   - [Description](#description)
   - [Key Features](#key-features)
2. [Prerequisites](#prerequisites)
3. [System Requirements](#system-requirements)
   - [Visual Studio](#visual-studio)
4. [Set Up Visual Studio](#setup-visual-studio)
5. [Instal and Compile Application](#install-and-compile-application)
   - [Install](#installation)
   - [Compile](#compile)
6. [Run Application](#run-application)
7. [Usage](#usage)
8. <mark>***[Reason for choosing Data Structures](#reason-for-choosing-data-structures)***</mark>
9. [Videos](#videos)
10. [References](#references)

<br/>


## Overview:
This Municipality Services Application provides an intuitive interface for South African citizens and municipal administrators, facilitated by using WPF. It is designed to help users engage with the municipality by reporting various issues and viewing dfferent events and announcements from the municipality. The application currently focuses on allowing users to report issues to the municipality and collecting feedback from users. Which is then stored in a Custom Doubly Linked List and displayed to admin users in the municipality. It also enables users to view all upcoming events and announcements from the municipality along with all their details. These details are stored in a custom sorted dictionary that makes use of a priority queue to optamise data storage, organisation and retrieval. Users are able see all service requests made in an asthetically pleasing manner, along with their status and progress. A heap is used to optamise the display of service requests in order of importance, while an AVL tree is used to store the details of all requests. Additionally a graph is used to effectively manage complex dependancies and relationships between requests. (Donlan, 2023; Guha, 2024; Martin, 2023).

<br/>

### Description

This application is dynamically designed to enhance user engagement with the municipality. Allowing users to actively report municipal issues in their community, provide feedback, view events, view announcements, search through events, and voice complaints to the municipality. The application continuously guides and prompts users as needed, providing success ad error messages, making it easy and efficient for users to report issues. The application incorporates various customer feedback mechanisms to enhance user engagement, such as a feedback form and star rating system. Allowing users to rate their experiences and give feedback on the quality of the application and services of the municipality. 

Municipal Administrators ae able to view all reported issues in a structured and well laid out manner, with all relevant details such as location, category, status, and attached documents or images. Administrators are able to view these reports and documents directly within the app, making the process easy and efficient. 

The application makes use of an asthetically pleasing design to display all upcoming events and announcements to the user. It also allows for comprehensive searching of events and announcements based on category, start date and end date, as well as any combination of the three. These search results are then passed to an algorithm that effectively makes reccomendations to the user in an asthetically pleasing manner.

The application makes use of an asthetically pleasing design to display all service requests, including their status and progress (in a progress bar) to the user. It allows the user to easily track the progress and status of their service request using a unique ID. It also allows for comprehensive searching of service requests, based on category, ID and Name, as well as any combination of the three. The application is able to display the information of the request in an asthetically pleasing manner, allong with all the prerequesits/ dependancies of the request in a well organised manner. 

(Donlan, 2023; Guha, 2024; Martin, 2023).

<br/>

### Key Features:
##### 1.	Issue Reporting:
   Soth African Citizens are able to report issues related to municipal services in their community to the municipality. These issues are then stored in a Custom Doubly Liked List for later use.
##### 2.	Admin Functionality: 
municipal administrators are able to log into the system to view the details of all reported issues, displayed in a DataGrid. 
##### 3.	Customer Feedback System: 
the user is able to engage with the system by providing feedback on various aspects of the application and providing a star rating out of 5. This allows the municipality to gather and analyse feedback on services to continuously improve and better meet citizen needs.
##### 4.	Responsive Design: 
the application is intuitively designed to dynamically adjust to different screen sizes to accommodate various users, achieved through the use of stack panels and WPF’s flexible layout management. 
##### 5.	Event and Announcement Display: 
the application is asthetically and effecively designed to display all upcoming events and announcements to the user in an asthetically pleasing manner, in order of unique dates and priority of the event based on the category. 
##### 6.	Search functionality: 
the application allows for intuative and effective searching of events and announcements based on unique categories, start date, end date or a combination of the three.  
##### 7.	Recomendation feature: 
The application keeps track of the users search history using a stack and uses this information to intuitively make recomendations to the user about upcoming events or announcements that they may like. 
(Hart, Booyens & Sinyolo, 2019).
##### 8.	Service Request Display: 
the application is asthetically and effecively designed to display all service requests and their status to the user in an asthetically pleasing manner, in order of priority. The user is also able to view the progress of the request in a progress bar.
##### 6.	Service Request Details: 
the user is able to view additional details about the service request by selecting the view details button next to each request.
##### 6.	Service Request Dependancies: 
the user is able to view all dependancies or prerequesite requests that need to be completed before the current service request can be completed. 
##### 10. Search and tracking functionality: 
it allows the user to easily track the progress and status of their service request using a unique ID. It also allows for comprehensive searching of service requests, based on category, ID and Name, as well as any combination of the three.

<br/>

## Prerequisites
1. Microsoft Visual Studio (2019 or later)
2. .NET Framework 4.7.2 or later

(Microsoft, 2024).

<br/>

## System Requirements

#### Visual Studio: 
1.	OperatingSystem:Windows10version1703orhigher,WindowsServer2016or later. 
2.	Processor:1.8GHzorfasterprocessor;Quad-coreorbetterrecommended. 
3.	RAM:Minimum:2GB(for basic workloads) 
4.	HardDiskSpace:Minimum1GBto40GBofavailablespace,depending on the installed features. 
5.	Graphics:DirectX11-capablevideocardwitharesolutionof1366x768or 
higher. 

(Microsoft, 2024).

<br/>

### Setup Visual Studio:
1.	Goto‘VisualStudioDownloads’inyourwebbrowseranddownloadthedesired edition. 
2.	Launch the Visual Studio Installer. 
3.	Choose the workloads relevant to your development needs. 
4.	Install Visual Studio. 
5.	After installation, sign in with your Microsoft account to activate the license. 

(Microsoft, 2024).

<br/>

## Install and Compile Application: 

<br/>

### Installation: 
##### 1.	Clone the GitHub repository provided: 
    https://github.com/VCDN-2024/prog7312-part-1-TanyaGov.git 
###### 1.1.	Open Visual Studio
###### 1.2.	Navigate to File then select Clone Repository
###### 1.3.	In the Clone a Repository window 
  ###### 1.3.1.	Locate the Repository Location field 
  ###### 1.3.2.	Paste the above GitHub Repo link here
###### 1.4.	Select a local destination for this project 
###### 1.5.	Select the Clone button to download the repo from GitHub.
##### 2.	Open the project in Visual Studio. 

(Martin, 2023; Mehta, 2023).

<br/>

### Compile:
1. Select the “PROG7321-POE.sin” file in Visual Studio
2. Navigate to Build then select Build Solution in Visual Studio
3. Make sure that no build errors occur. 

(Martin, 2023; Mehta, 2023).

<br/>

## Run Application:
###### 1.	Navigate to debug and select Start debugging (Ensure that you Compile the solution first). 
###### 2.	The application will now launch and the main menu window will appear on the screen. 
###### 3.	To Report issues select the ‘Report issues’ button.
3.1.	For more details refer to [Usage](#usage) or the video explanation attached. 
###### 4.	To view issues as an admin select the ‘Admin’ button.
4.1.	For more details refer to [Usage](#usage) or the [Video](#video) explanation attached.
###### 5.	To view upcoming events and announcements select the 'Events and Announcements' button.
5.1.	For more details refer to [Usage](#usage) or the [Video](#video) explanation attached.
###### 6.	To view service requests select the 'Service Requests' button.
6.1.	For more details refer to [Usage](#usage) or the [Video](#video) explanation attached.

<br/> 
(Martin, 2023; Mehta, 2023).

<br/>

<br>


## Usage:
<br/>

### 1. Reporting Issues:


##### 1.1.	Select the Report Issue button on the main menu – this will redirect you to the report issue page
##### 1.2.	Fill out your location in the text box provided (Next to ‘Location’ label)
##### 1.3.	Select a municipal issue category from the drop down list provided
##### 1.4.	Fill out the description of the issue in the rich text edit provided (Below the ‘Description’ label)
##### 1.5.	Optionally click the ‘attach document’ button to add a document to the report:
###### 1.5.1.	Click the button the select the desired file from your device
###### 1.5.2.	Select save 
##### 1.5.3.	A success message will appear to confirm that your document has been attached. 
##### 1.6.	The progress bar at the bottom of the page will begin to fill, once all the compulsory field are filled the ‘Submit’ button will become enabled
##### 1.7.	Select the ‘Submit’ button
###### 1.7.1.	A success message will confirm that the issue has been successfully reported to the municipality.
##### 1.8.	If you no longer wish to report an issue select the ‘Back’ button which will return you to the Main menu of the application. 
<br/>
(Martin, 2023; Mehta, 2023).

<br/>
<br/>

### 2. Customer Feedback:


##### 2.1. Once the issue is reported the Feedback Form will appear.
##### 2.2. Provide feedback to the municipality by filling out the form on what you liked, disliked and what can be improved about the application
##### 2.3. Provide a rating for the system by selecting a star out of 5
##### 2.4. Once all these fields are completed select the ‘Submit’ button to send the feedback to the municipality
##### 2.5. To return to the main menu without providing feedback select the ‘Back’ button.
<br/>
(Donlan, 2023; Team Storyly, 2024).

<br/>
<br/>


### 3. Administrative Function: 


##### 3.1. Select the Admin button on the main menu – this will redirect you to the admin page 
##### 3.2. Enter in your Admin username and password and then select the login button
##### 3.3. If the credentials are correct the panel containing the details of all the reported issues will become visible.
##### 3.4. The details of the reported issues will appear in the DataGrid 
##### 3.5. To view the document attached to the report select the ‘View Document’ button at the end of the reported issue row
##### 3.6. If a document was attached to the report then the document will open in the web browser component below the DataGrid. If no image was attached then a message will appear to indicate this
##### 3.7. To navigate back to the main menu select the ‘Back’ button
<br/>
(Donlan, 2023; Team Storyly, 2024).

<br/>
<br/>


### 4. View Local Events and Announcements:


##### 4.1. Select the Events and Announcements button on the main menu – this will redirect you to the events page 
##### 4.2. All upcoming events and announcements provided by the municipality will appear on the page in an asthetically pleasing manner.
##### 4.3. Scroll down using the scroll bar on the side to view more events.
##### 4.4. To navigate back to the main menu select the ‘Back’ button.

<br/>
(Donlan, 2023; Team Storyly, 2024).
<br/>
<br/>


### 5. Search Functionallity: 


##### 5.1. At the top of the page there are 3 components and 2 buttons.
##### 5.2. To filter by category select the category you want from the dropdown box on top of the page and then select the search button. The events will then be filtered and displayed to you.
##### 5.3. To filter by start date of event select thestart date you want from the date picker on top of the page and then select the search button. The events will then be filtered and displayed to you.
##### 5.4. To filter by end date of event select the end date you want from the date picker on top of the page and then select the search button. The events will then be filtered and displayed to you.
##### 5.5. A combination of these 3 can be used by selecting the values you want and selecting the search button.
##### 5.6. To view all events again select the View all events button. 
<br/>
(Donlan, 2023; Team Storyly, 2024).

<br/>
<br/>


### 6. View All Service Requests:


##### 6.1. Select the Service Requests button on the main menu – this will redirect you to the service requests page 
##### 6.2. All service request, along with their status, reported to the municipality will appear on the page in an asthetically pleasing manner.
##### 6.3. Scroll down using the scroll bar on the side to view more requests.
##### 6.4. To navigate back to the main menu select the ‘Back’ button.
<br/>
(Donlan, 2023; Team Storyly, 2024).

<br/>
<br/>


### 7. View All Service Requests:


##### 7.1. To view more information about a service request select the 'View Details' button next to the service request. 
##### 7.2. All information about the service request will now be displayed.
##### 7.3. At the botton of the page all dependancies/ prerequesites of the service request will be shown. This is all requests that need to be completed before the current request can be completed. 
##### 7.4. To view more information about a dependancy select the 'View Details' button next to the service request dependancy. All information about the dependancy will now be displayed.
##### 7.4. To navigate back to all service requests select the ‘Back’ button.
<br/>
(Donlan, 2023; Team Storyly, 2024).

<br/>
<br/>


### 8. Tracking and Search Functionallity: 


##### 5.1. At the top of the service request page there are 3 components and 2 buttons.
##### 5.2. To track a specific service request, enter in the id of the service request and select the search button. The service request will then be displayed.
##### 5.1. To filter by category select the category you want from the dropdown box on top of the page and then select the search button. The requests will then be filtered and displayed to you.
##### 5.1. To filter by name of the request, enter in the name of the service request top of the page and then select the search button. The requests will then be filtered and displayed to you.
##### 5.1. A combination of these 3 can be used by selecting the values you want and selecting the search button.
##### 5.1. To view all requests again select the View all requests button. 
<br/>
(Donlan, 2023; Team Storyly, 2024).

<br/>
<br/>


## Reason for choosing Data Structures

<br/>
The Municipal Services Application incorporates advanced custom generic data structures to efficiently manage reported issues, service requests, local events and announcements. Below is an explanation of the data structures chosen for this application, their role in the project, and how they enhance the efficiency of the application.
<br/>

#### 1. Custom Sorted Dictionary:
A custom sorted dictionary is used to effectively store, organise and retrieve event information. A custom sorted dictionary allows for a key to store unique dates, and prevents duplicate dates from being stored. Further more creating a SORTED custom dictionary allows for these dates to be arranged in descending order from the most recent date to the date furthest from today. This custom sorted dictionary also allows for the value of the key to store a priority queue of all events that occur on a specific day, correlating to a specific unique key. 
(GeeksForGeeks, 2018); (GeeksForGeeks. 2019); (Stack Overflow, 2024).
<br/>

#### 2. Custom Priority Queue:
A custom priority queue is used as needed to manage event related data structures effectively. A custom priority queue is used within te sorted dictionary. This allows for a sorted queue to effectively manage all events that happen on the same day. Furthermore creating a custom PRIORITY queue allows for all events to be stored in order of importance or priority, showing the most important events firts and the least important events last. 
(GeeksForGeeks, 2018); (GeeksForGeeks. 2019); (Stack Overflow, 2024).
<br/>

#### 3. Custom Hash Set:
A custom hash set is incorporated to handle unique categories efficiently. This custom stack is able to store UNIQUE categories for all events and prevents duplicate categories from being stored. This opamises the search function as only categories that can events in them are displayed to the user to select from. Rather than displayng all possible categories to the user even if there are no events in this category. 
(GeeksForGeeks, 2018); (GeeksForGeeks. 2019); (Stack Overflow, 2024).
<br/>

#### 4. Custom Stack:
A custom stack is used as needed to manage event related data effectively. The search history of the user is stored in the custom stack. This is effective as the algorithm for recomendation uses the five most RECENT searches to generate recomendations, as this optamises the search and prevents outdated or irrelevant recomendations. A stack is most suited for this as it uses the Last In First Out approach storing the 5 most recent searches at the top of the stack where it is easily accessible. 
(GeeksForGeeks, 2018); (GeeksForGeeks. 2019); (Stack Overflow, 2024).
<br/>

#### 5. <mark>***Custom AVL Tree:***</mark>

The custom, generic AVL tree developed is used to store, organise, and retrieve information about service requests using a sortable key, while keeping the tree balanced for efficient operations. An AVL Tree is an advanced binary search tree that is able to self-balance. This allows for efficient insertion, deletion, and search operations. It is effective and best suited for the Municipal Service Application because it can maintain a balanced structure, making it ideal for efficiently processing dynamic service request data. An AVL tree ensures that the height difference between any node's left and right subtrees is less than or equal to one. This ensures that the tree remains balanced while reducing the temporal complexity of operations. Balancing guarantees that no part of the tree becomes too deep, resulting in predictable and efficient performance. Service requests are routinely added, updated, and deleted from the AVL tree. The AVL tree can adjust itself upon each insertion or deletion, preventing skewed structures. This makes searching for individual service requests extremely efficient, even as the number of requests grows.

An AVL Tree was chosen over a binary tree for this application because it is more efficient, with each node having only two children: the left node carrying values less than or equal to the parent node's value, and the right node containing values greater than the parent node's. This significantly improves the efficiency of data searching and organisation. An AVL Tree was chosen for this application over a binary search tree because it is more effective, whereas a binary search tree can become imbalanced, resulting in poor performance. An AVL tree can self-balance, avoiding this problem. 

The AVL tree sorts service requests according to their submission timestamps. This allows for speedy retrieval of the oldest or newest request, making it easier for municipal workers to complete tasks in the order they were received.

(Microsoft, 2024; (StackOverflow, 2012); (StackOverflow, 2019).
<br/>

#### 6. <mark>***Custom Heap:***</mark>

A heap is a specialised tree-based data structure that satisfies the heap property. In a heap, the key root is either the min or  max key value in the tree. A custom, generic min heap was constructed to store the status, ID, title, progress, and priority of various service requests, which is then utilized to optimize the display of service requests in order of priority. The min heap structure keeps the element with the smallest key at the root of the tree, making it easy to access. This enables the municipal services application to efficiently select and retrieve the most critical service requests first. Service requests can be dynamically added to the heap with minimal time complexity, allowing the application to easily add urgent requests and reprioritise them. 

A heap is an efficient technique to handle and execute service requests in order of urgency without having to sort the entire dataset multiple times. Ensuring that the user sees the service request with the highest urgency first. For example, requests with higher urgency, such as fixing the electricity, are automatically placed to the front of the processing queue, while less urgent chores, such as cleaning up the area, are deferred until higher-priority requests are completed. The use of a heap makes accessing the minimum element, as well as insertion and removal efficient, as the heap maintains its order through re-heapification.

Extracting the minimum/highest priority element from a min-heap is more efficient and faster than using linked lists or arrays. The min heap allows direct access to the highest-priority element, making it more appropriate than an AVL tree, which is effective for key-based searches and updates but less efficient for priority-based extractions. A heap was chosen over a graph, because graphs are not optimized for keeping and extracting priorities. As a result, the heap was the most appropriate data structure for this function in the application. 

(Microsoft, 2024; (StackOverflow, 2012); (StackOverflow, 2019).
<br/>

#### 7. <mark>***Custom Graph:***</mark>

A Graph is a complex and dynamic data structure represents relationships between different nodes using edges. A custom, generic dependency graph was used in the municipal services application to manage complex relationships between service requests. The dependency graph is able to represents relationships between different service requests, where certain requests depend on the completion of others requests. For example, fixing a streetlight requires that the electricity is fixed first. Each node in the graph represents a service request, and directed edges represent dependencies. This allows the application to manage complex relationships between requests and ensures requests are executed in the correct sequence.

Graphs allow for a clear representation of dependencies between service requests, therefore dependencies can be explicitly defined and managed in the application efficiently. The Depth-First Search, graph traversal algorithms, was used to effectively detect and resolve dependencies as well as identify request execution sequences based on dependencies. The Graph helps to identify and resolve circular dependencies between service requests, where two or more requests are mutually dependent on each other, preventing progress. This allows the application to easily resolve conflicts or prioritize requests appropriately. The use of this graph allows users to see which requests are pending and their prerequisites and dependencies.

A graph was chosen over an AVL tree, as AVL trees are designed for sorting data and fast lookups but are not able to model complex relationships between nodes. Heaps are effective for priority-based tasks but cannot manage dependencies between nodes. Different lists and dictionaries are also unable to model complex relationships dynamically between nodes. Therefore, the graph data structure was the best suited as it is able to capture and manage complex relationships between nodes.

(Microsoft, 2024; (StackOverflow, 2012); (StackOverflow, 2019).
<br/>

<br/>

<br>



## Videos

##### Watch a Quick Video of How to Run and use the code: 

###### Reporting Issues and Administrative Function:
<a href="https://youtu.be/sG_WtxFFxA4" target="_blank">
  <img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" alt="YouTube Icon">
</a>

###### Events and Announcements:
<a href="https://youtu.be/JiwFVCXbGwA" target="_blank">
  <img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" alt="YouTube Icon">
</a>

###### Service Request Status:
<a href="https://youtu.be/5JryNxntfKo" target="_blank">
  <img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" alt="YouTube Icon">
</a>

(Martin, 2023; Mehta, 2023).

##### References
###### Donlan, K. 2023. 5 Customer Engagement Strategies for Leading E-Commerce Brands, 24 August 2024. [Online]. Available at: https://emarsys.com/learn/blog/5-customer-engagement- strategies-ecommerce/ [Accessed 07 September 2024].

###### GeeksForGeeks. 2018. Implementing Stack in C#, 30 October 2018. [Online]. Available at: https://www.geeksforgeeks.org/implementing-stack-c-sharp/ [Accessed 12 October 2024].

###### GeeksForGeeks. 2019. How to create a Queue in C#, 18 February 2019. [Online]. Available at: https://www.geeksforgeeks.org/how-to-create-a-queue-in-c-sharp/ [Accessed 04 October 2024].

###### GeeksForGeeks. 2023. Linked List Implementation in C#, 17 January 2023. [Online]. Available at: https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/ [Accessed 18 September 2024].

###### Guha, P. 2024. Mastering Brand Engagement: Strategies and Real-Life Examples, 08 July 2024. [Online]. Available at: https://vwo.com/blog/mastering-brand-engagement-strategies/ [Accessed 05 September 2024].

###### Hart, T. G. B., Booyens, I. and Sinyolo, S. 2019. Innovation for Development in South Africa: Experiences with Basic Service Technologies in Distressed Municipalities. Forum for Development Studies. [Online]. DOI: 10.1080/08039410.2019.1654543 [Accessed 10 September 2024].

###### Martin, M. 2023. 17 Customer Engagement Strategies To Enhance the Customer Experience, 11 May 2023. [Online]. Available at: https://smith.ai/blog/customer-engagement-strategy [Accessed 06 September 2024].

###### Mehta, J. 2023. How to increase your website and page engagement [Ultimate guide], 17 November 2023. [Online]. Available at: https://abmatic.ai/blog/ways-to-increase-your- website-engagement [Accessed 07 September 2024].

###### Microsoft. 2022. Visual Studio: IDE and Code Editor for Software Development. [Online]. Available at: https://visualstudio.microsoft.com/[Accessed 31 May, 2024].

###### Microsoft. 2024. Build a custom Microsoft Graph connector in C#, 11 July 2024. [Online]. Available at: https://learn.microsoft.com/en-us/graph/custom-connector-sdk-sample-create [Accessed 12 November 2024].

###### StackOverflow. 2012. .NET Built-in AVL-Tree?, 29 June 2012. [Online]. Available at: https://stackoverflow.com/questions/8768687/net-built-in-avl-tree [Accessed 10 November 2024].

###### StackOverflow. 2019. .Net custom heap generation, 06 February 2019. [Online]. Available at: https://stackoverflow.com/questions/54548977/net-custom-heap-generation [Accessed 12 November 2024].

###### Stack Overflow. 2024. Want to create a custom class of type Dictionary<int, T>, 18 June 2024. [Online]. Available at: https://stackoverflow.com/questions/963068/want-to-create-a- custom-class-of-type-dictionaryint-t [Accessed 10 October 2024].

###### Team Storyly. 2024. 12 Amazing Customer Engagement Ideas You Can't Ignore, 05 April 2024. [Online]. Available at: https://www.storyly.io/post/customer-engagement-ideas [Accessed 06 September 2024].
