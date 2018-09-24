<p>
  <img align="left" src="./Documentation/uofr_logo.jpg" alt="U of R logo" height="90px"/>
  <img align="right" src="./Documentation/ehealth_logo.png" alt="eHealth logo" height="90px"/>
</p>

<br/><br/><br/><br/>

---

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. INTRODUCTION](#1-introduction)
  - [1.1.	Purpose](#11%09purpose)
  - [1.2.	Scope](#12%09scope)
  - [1.3.	Background](#13%09background)
  - [1.4.	Assumptions and Constraints](#14%09assumptions-and-constraints)
  - [1.5.	Document Overview](#15%09document-overview)
- [2. METHODOLOGY](#2-methodology)
  - [2.1.	Data Gathering](#21%09data-gathering)
  - [2.2.	Requirements Analysis](#22%09requirements-analysis)
  - [2.4.	User Evaluation](#24%09user-evaluation)
  - [2.5.	High-Fidelity Prototyping](#25%09high-fidelity-prototyping)
- [3. System Design](#3-system-design)
  - [3.1. Context Diagram](#31-context-diagram)
  - [3.2. Data Flow Diagram](#32-data-flow-diagram)
  - [3.3. Logical Data Model Diagram](#33-logical-data-model-diagram)
- [4. Functional Requirements](#4-functional-requirements)
  - [4.1.	Login](#41%09login)
  - [4.2. Logout](#42-logout)
  - [4.3.	Update Profile](#43%09update-profile)
  - [4.4.	Search for Ideas](#44%09search-for-ideas)
  - [4.5.	Filter ideas](#45%09filter-ideas)
  - [4.6.	View Notification Center](#46%09view-notification-center)
  - [4.7.	View Dashboard](#47%09view-dashboard)
  - [4.8.	View Success Stories](#48%09view-success-stories)
  - [4.9.	Subscribe and View Subscribed Ideas](#49%09subscribe-and-view-subscribed-ideas)
  - [4.10. Give feedback](#410-give-feedback)
  - [4.11.Add New Idea and View My Ideas](#411add-new-idea-and-view-my-ideas)
  - [4.12. Give Actions](#412-give-actions)
- [5. Non-Functional / Other Requirements](#5-non-functional--other-requirements)
  - [5.1. Interface Requirements](#51-interface-requirements)
  - [5.2.	Data Conversion Requirements](#52%09data-conversion-requirements)
  - [5.3.	Hardware/Software Requirements](#53%09hardwaresoftware-requirements)
  - [5.4.	Operational Requirements](#54%09operational-requirements)
    - [5.4.1. Security and Privacy](#541-security-and-privacy)
    - [5.4.2. Reliability](#542-reliability)
    - [5.4.3.Recoverability](#543recoverability)
    - [5.4.4. System Availability](#544-system-availability)
    - [5.4.5. General Performance](#545-general-performance)
    - [5.4.6. Data Retention](#546-data-retention)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->


# 1. INTRODUCTION

## 1.1.	Purpose
The purpose of this document is to describe in detail the system proposed to be implemented to address the eHealth need for a system which can gather the employees ideas, sort it, follow it up through the whole process, enable interaction between employees on department level as well as on organization level.

## 1.2.	Scope
This document describes the system functionality, describing the methodology applied in detail, detailing the functional requirements, mentioning each interface, its links, menus, pop-up menus and icons.

## 1.3.	Background
eHealth Saskatchewan (eHS) is a Treasury Board Crown within the province of Saskatchewan providing Information Technology (IT) support to Saskatchewan’s health sector. Through the vision “Empower Patients. Enable Care,” eHS has a goal and purpose to improve the quality of health care across the province for both patients and health care providers. In the organization’s ongoing effort to achieve this goal and purpose, eHS focuses on the sustainability of their services by fostering an internal culture of innovation. In operationalizing a culture of innovation, eHS employees are encouraged to individually and collaboratively trial new ideas and innovations through Plan, Do, Check, Act (PDCA) cycles with the goal of improving quality, cost, delivery, safety, and engagement within eHS.
A tool was developed called Challenge 100 which unfortunately didn’t succeed in fulfilling the goals it has been design for, where many deficiencies are reported which hundred reaching the ultimate goal.
An initiative has been taken to re-brand the tool to “eIDEAS” and re-envisioning the people, process, and technology interactions through a current and future state process mapping activity. Through this, the team assessed and redeveloped the design, delivery, and tracking methods to support eHealth's ongoing journey to transform the way they work. eHS wants the re-imagined eIDEAS tool to empower a sustainable internal culture of innovation, better enabling the sharing of ideas and the visibility of individual and collaborative work. The focus of eIDEAS is to begin with an idea at the local level (maximum of one work unit), visualizing the work from following key activities.

![alt text](https://raw.githubusercontent.com/semo94/eIDEAS1/master/Documentation/Diagrams/activites.png)

## 1.4.	Assumptions and Constraints
Assumptions are future situations beyond the control of the project, whose outcomes influence the success of a project. Examples on assumptions include: availability of a technical platform, legal changes and policy decisions, and the willingness of employees to use this system effectively.
Constraints exist because of real business conditions. For example, a delivery date is a constraint only if there are real business consequences that will happen as a result of not meeting the date. If failing to have the subject application operational by the specified date places the organization in legal default, the date is a constraint.

## 1.5.	Document Overview
The document is divided into five main sections, an Introduction shedding light about the purpose and scope of this document, followed by a Methodology describing in a simple way how the project will achieve its objectives, Then the system architecture and design graphical representation. After that, the documentation will discuss the functional requirements of this system, and finally ends up with describing its nonfunctional/other requirements.

# 2. METHODOLOGY

## 2.1.	Data Gathering
Our first objective is to understand the legacy system and its problems. Furthermore, we need to have an in-depth perspective of the needs of the targeted users. this will be achieved by meeting one of their representative teams and read some documents that describe the company's final expectations of the eIDEAS system.

## 2.2.	Requirements Analysis
The main objective of this phase is to analyze our initial findings and conclude a documented plan of how this system architecture will be implemented.
2.3.	Low-Fidelity Prototyping
In this milestone, we will craft some sketches either by hand or by using software tools. These sketches will reflect the essential imagination of eIDEAS system. we will use these low-Fed prototypes to help us producing accurate user evaluation in the next step.

## 2.4.	User Evaluation
This phase aims to observe selected user sample from eHealth Saskatchewan and evaluate their interaction workflow with our prototype and collect their feedback in quantitative and qualitative manner. This will be achieved by filling questionnaire surveys in addition to interviewing these users and observe them in-person.

## 2.5.	High-Fidelity Prototyping
Finally, this phase will produce informative decisions based on our previous user evaluation outcomes. Then we will reflect those decisions on our current functionality specifications and prototype in order to develop a high-fidelity prototype using Balsamiq tool. The newest prototype will represent the updated workflow and the behavior of the eIDEAS system.

# 3. System Design

## 3.1. Context Diagram

![alt text](https://raw.githubusercontent.com/semo94/eIDEAS1/master/Documentation/Diagrams/Context.png)

## 3.2. Data Flow Diagram

![alt text](https://raw.githubusercontent.com/semo94/eIDEAS1/master/Documentation/Diagrams/DFD.png)

## 3.3. Logical Data Model Diagram

![alt text](https://raw.githubusercontent.com/semo94/eIDEAS1/master/Documentation/Diagrams/LogicalDataModel.png)

# 4. Functional Requirements

## 4.1.	Login
All users must provide their predefined username and password in order to login to the system. Users would be directed to the right portal based on their privileges.
  •	Users should insert their email address and password.
  •	Users should click on the “Login button” after filling the correct information
  •	eIDEAS will authenticate the user credential from its database.
  •	If users credential was valid, eIDEAS will redirect user to their landing page portal.
  •	If user credential was invalid, eIDEAS will give users a feedback asking to re-enter the correct information.
  •	If users forgot their own credential information, users shall be able to click on “Forget User ID or Password”
  •	eIDEAS will give a popup message to redirect users to the available help-desk employee.

## 4.2. Logout
All users should be able to logout from their eIDEAS portal any anytime from anywhere.
  •	Users should click on the “User Name” icon from the top left window.
  •	Users will see a small window containing two action button which are “Update Profile” and “Logout”.
  •	Users should click on the “Logout” button.
  •	eIDEAS will terminate users’ current session and redirect them to the login screen.

## 4.3.	Update Profile
At any time, users should be able to update their profile information in addition to change their profile picture.
  •	Users should click on the “User Name” icon from the top left window.
  •	Users will see a small window containing two action button which are “Update Profile” and “Logout”.
  •	Users should click on the “Update Profile” button that includes, but not limited to, username, email address, work phone extension, mobile phone number, and password.
  •	eIDEAS will redirect them to the profile page.
  •	From there, users should be able to change their profile information by typing them down in the edit boxes.
  •	Users can also click on “Upload” button in order to change their profile picture.
  •	eIDEAS will prompt a popup screen letting users to browse and chose their new profile picture that want to upload.
  •	One they finish, users should click on the “Save” button.
  •	eIDEAS will update users profile information on the database, reflect them in their profile information, and redirect the users to the previous portal screen.

## 4.4.	Search for Ideas
Users should be able to write a text query in a search bar in order to get the most accurate ideas results that match their inserted query based on the idea number, ideas owner name idea title, and idea description.
  •	Users should click on the search bar that located in top center window.
  •	User should write their wanted query inside the search bar.
  •	User should click on the search icon or hit enter.
  •	eIDEAS will initiate a database query and return the matched results.
  •	eIDEAS will filter the ideas and populate them based on the inserted user’s query.

## 4.5.	Filter ideas
Users should be able to filter all ideas by its status (pending, approved, declined, parked, planned), by ideas number, subscribed ideas, by team name, and by team member.
  •	Users should click on the filter sub down list which located on the top center window.
  •	User should select the filter option that they want.
  •	eIDEAS will filter all ideas based on the selected filter option and then show the results in the same user’s window.

## 4.6.	View Notification Center
Users should be able to view their received notification messages at anytime from anywhere inside the eIDEAS portal.
  •	eIDEAS should populate a notification counter to notify users with their new messages.
  •	Users should click on the notification icon which located on the top right window.
  •	eIDEAS will open a small sub window showing the new messages that’s been sent to the users.
  •	Users can view their messages and click on any of them to be redirected to the appropriate screen.
  •	If the users didn’t login into eIDEAS for a whole day, eIDEAS will automatically send a digest email to the users that includes all of their unseen notification messages.

## 4.7.	View Dashboard
Users should be able to view their dashboard screen at anytime from anywhere inside the eIDEAS system.
  •	From the left side bar, users should click on the “Dashboard” tab.
  •	eIDEAS will redirect users to the dashboard screen and show the results based on their privileges.
  •	If the users are managers, they should get useful statistical information including but not limited to key performance indicators, budget breakdown, approved ideas by departments (pie chart), and ideas statues (bar chart).
  •	If the users are team members, they should get useful statistical information including but not limited to idea of the month, and other useful statistical information.

## 4.8.	View Success Stories
Users should be able to view all of the successful ideas stories that’s been approved, planned, and implemented and effect the work environment in a positive way.
  •	From the left side bar, users should click on the “Success stories” tab.
  •	eIDEAS will redirect users to the “success stories” screen and show the results.
  •	From this page, users can view each idea’s information such as the owner name, idea’s title and description, comments and likes, and the rank that’s been given to the idea submitter.

## 4.9.	Subscribe and View Subscribed Ideas
Users should be able to follow (subscribe) to the ideas that may interested in for later revision.
  •	Users should click on the subscribe like that appears on the top right of each idea, except their own ideas.
  •	Users should click on “Subscribed Ideas” tab from the left sidebar.
  •	eIDEAS system will show all the ideas that this user has subscribed to.
  •	Users also can click on the “Unsubscribe” like that appears on the top right of each subscribed idea to remove it from the subscription list.

## 4.10. Give feedback
Users should be able to give a feedback such as, like the idea, comment on the idea, and chat with idea’s owner. Users should be able to give their feedback at anytime from anywhere inside IDEAS system.
  •	From each idea box, users can click on the like icon to like the idea.
  •	eIDEAS system will increase the ideas counter and view it inside the idea box.
  •	From each idea box, users can click on the comment icon.
  •	eIDEAS system will collapse the idea box down and show preview comment with an edit textbox.
  •	Users can write down their comment in the textbox then click on the “Submit Button”
  •	The comments counter will increase and if the user clicks on it will displays all the previews comments including its own.
  •	User can click on the chat icon to start a private conversation with idea’s submitter. Note that this feature is not represented completely in the accomplished prototype.

## 4.11.Add New Idea and View My Ideas
Team members only should be able to add a new idea of an internal business meeting with their other team members, team leader and or manager.
  •	Team members should click on the “New Idea” tab from the left side bar.
  •	eIDEAS will redirect team members to the add new idea screen and generate a new idea number.
  •	Team members must write the problem title which has to be up to 255 characters.
  •	Team members should add the problem description alongside with any proposed solutions for it.
  •	Team members should click on the submit button once they finish filling up the required information.
  •	eIDEAS will save the idea information in its database, populate the new idea in the system, and redirect the team members to their “My Ideas” tab.
  •	From the lift side bar, team members can click on “My Ideas” tab in order to view, interact, and give actions on their own ideas.

## 4.12. Give Actions
Team members, team leader and managers should be able to give actions on certain ideas based on their own privileges. Each team member can only act on the ideas that their own, while managers and team leaders have the privilege to give actions on other team members ideas. That Actions might differ and restricted based on the type of the user as well as the current idea’s status.  

For the team members:

  •	Users should click on the “My Ideas” tab from the left side bar to view their own ideas.
  •	Users can click on the action drop down button which located on the top right side of each idea box.
  •	Users can choose their willing action from the available options in the actions list.
  •	If the idea still in the “Pending Status”, users can edit, park, decline, delete, and plan the idea as following:

*Edit: after users clicked on the “Edit” option, eIDEAS system will prompt a screen that contains the current idea’s information and edit textboxes. Users should fill the text boxed with the new information then click on the “Submit” button. The eIDEAS system will updated its database with the newest values, reflect that on the other screens, and redirect the users back to their “My Ideas” tab.*

*Decline: after the users clicked on “Decline” option, eIDEAS system will prompt a screen that contains idea’s owner name, the idea’s number, and an edit text box. The users should write down the reasons behind declining their own idea then click on the “Submit” button. The eIDEAS system will update its database value, reflect the new idea status on the other screens, and redirect users back to their “My Ideas”.*

*Park: after the users clicked on “Park” option, eIDEAS system will prompt a screen that contains idea’s owner name, the idea’s number, and an edit text box. Users should write down why this idea will be moved to the parking lot then click on the “Submit” button. eIDEAS system will update its database values, changing this idea status and reflected on other screen, and redirect the users back to their “My Ideas” tab.*

*Delete: when the users click on “Delete” option, eIDEAS system will prompt a popup screen to confirm this action, if users click on confirm, the idea will be removed from the system database, reflected on other screens, and redirect the users back to their “My Ideas” tab.*

*Plan: Only when the idea has been approved by the manager, “Plan” option will be activated to be chosen from the ideas submitter. After the users clicked on “Plan” option, eIDEAS system will prompt a screen that contains idea’s owner name, the idea’s number, and an edit text box. Users should fill in their plan details and how this idea will be an improvement to their work environment then click on the “Submit” button. eIDEAS system will update its database records, change and reflect the idea’s status on other screens, and redirect back the users to “My Ideas”.*

  •	In case the idea is on “Parked Status”, users can plan, edit, decline and delete at any time.
  •	In case the idea is on “Declined Status”, users can only take a delete action.
  •	In case the idea is on “Plan Status”, users can only park or delete this idea.

For the managers/team leaders:

  •	Users can give actions on any idea coming from one of their team members.
  •	The actions that could be taken are: approve, decline, park, delete, and do the idea which is one of the (PDCA Procedure).
  •	Note that “Do” feature is not represented in the current accomplished prototype.
  •	Note that all actions that will be taken on this system will be based on internal business meeting and polices. The system will be responsible only to manage the work flow between all parties and produce a unified interactive interface. Thus, notification messages will be generated automatically between all users based of their taken actions.

# 5. Non-Functional / Other Requirements
The web application (eIDEAS) shall be easy to use by all employees by decreasing the amount of scrolling the page for information and less number of clicks to achieve the desired output. The web application shall allow multiple users within the scope (team) to enter their ideas without affecting the performance of the application.

## 5.1. Interface Requirements
The user interface will accept input from mice, trackpads, and keyboard only. The hardware interface is a server that could be able to serve authenticated users over the network. On the software interface side, it will be a web server application with the employees’ accounts (Active directory list) for authentication. Also, the web application will interface with an RDB like MySQL and/or NoSQL database like MongoDB).

## 5.2.	Data Conversion Requirements
Data will be stored in database as plain text except large words can be replaced by one character.

## 5.3.	Hardware/Software Requirements
The minimal acceptable requirement to have this system running are:
  •	2.0 GHz CPU speed, 4 GB of RAM, 128 GB of HDD.
  •	Microsoft Windows 7 or later, Mac OS, or Linux distribution
  •	Internet explorer 11, Mozilla Firefox, Google Chrome or Safari internet browser.

## 5.4.	Operational Requirements
The web application will ask for dialogue prompt when data is not saved before proceeding to another screen. When the user types in some predetermined values (e.g. team name, staff name), the system will generate suggestion list to choose the rest of the value. Any disabled field will be provided with a description of the reason behind it.

### 5.4.1. Security and Privacy
All authenticated user should protect their account information. User must log out when accessing the information at public computer. The data may be lost or not readable when exposed under computer attack or viruses. The private information can be disclosed to unauthenticated users when not logged out on public computers.

### 5.4.2. Reliability
Any damage to the application from power shutdown can result in loss of unsaved data Any physical damage to the hardware will result in loss of data since last backup.

### 5.4.3.Recoverability
In the event of unavailability of the application, the web application should be back up running within 24 hours of the first reported time.

### 5.4.4. System Availability
The web application will be available to user 22 hours (4 AM to 2AM next day) of each day of the week. System will be out of service for the rest for backup.

### 5.4.5. General Performance
The response time for a query or update can vary substantially depending upon the volume of the data. User will be provided with a waiting screen to a maximum of 10 seconds and then error will be presented.

### 5.4.6. Data Retention
The user data will be retained in the database for one year before backing up permanently on a storage device.
