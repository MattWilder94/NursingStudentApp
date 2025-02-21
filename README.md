# Nursing Student Web App

## Overview
The **Nursing Student Web App** is designed to assist professors at **Walter State Community College** in determining student eligibility for the nursing program. The application is a digital transformation of an Excel-based system currently used by the nursing department. By automating calculations and streamlining data entry, the app provides a more efficient and user-friendly way to track and manage student information.

## Features
- **Student Management**: Professors can add and update student records.
- **Exam Data Entry**: Support for ACT and major college exam score entry.
- **Grade Tracking**: Professors can input and manage student grades.
- **Prerequisite Progress Monitoring**: Tracks students' progress through required prerequisite courses.
- **User Roles**:
  - **Admin**: Manages student records, including grades, test scores, and course completion.
  - **Student**: Views personal information, grades, and requirement completion status.
  - **Analytics (Future Feature)**: Provides anonymized student data for statistical analysis.
- **Analytics (Future Feature)**: Ability to query non-identifying student data for trend analysis and reporting.

## Technology Stack
- **Backend**: .NET MVC, C#, SQL Server
- **Frontend**: JavaScript, Bootstrap, HTML, CSS

## Setup Instructions
### Prerequisites
- **IDE**: Visual Studio or a similar .NET development environment
- **Database**: SQL Server (ensure the database context is configured properly)
- **Git**: For cloning the repository

### Installation Steps
1. Clone the repository from GitHub:
   ```bash
   git clone https://github.com/MattWilder94/nursing-student-webapp.git
   cd nursing-student-webapp
   ```
2. Open the project in Visual Studio.
3. Configure the SQL Server database connection in the context file.
4. Run the project to launch the web app.

## Usage
- **Login System** (Planned Implementation): The app will feature a login system for different user roles (Admin, Student, Analytics).
- **Admin Role**: Can update student information, including grades, test scores, and class progress.
- **Student Role**: Can view their personal data, including grades and completion status.
- **Analytics Role (Future)**: Can analyze anonymized student data to generate reports and insights.

## Future Improvements
- Implementation of an **analytics dashboard** to allow statistical analysis of student performance data.
- Enhanced role-based access control.
- Additional reporting tools for professors to monitor student trends.

## License
This project is for educational and internal use within **Walter State Community College**.

## Contact
For any inquiries, please contact the project developers.
