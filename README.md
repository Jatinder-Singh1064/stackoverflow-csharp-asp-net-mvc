# stackoverflow-csharp-asp-net-mvc
Stackoverflow is ASP.NET MVC based Web Application implementing Entity Framework along with Authentication using Microsoft Identity Framework which mimics the original Stackoverflow website and its operations.
Objective - Start building a question/answer discussion board similar to stackoverflow using MVC ASP.NET.
Build an ASP.NET MVC Application to mimic a single user question and answer forum; similar to stackoverflow with the ability to answer questions.
You are also required to implement authentication and user registration using the Identity framework.
At the very top, the following links should be available for the user:
- Home:Takes you to the home page of the application
- About : provides static content to the user about this web site
- Contact: provide static content to the user on how they can contact you
- Categories navigates you to the categories page where you will see a list of the following categories dynamically retrieved from the database.
- Question Navigates the user to a list of questions that have already been asked dynamically retrieved from the database. 
- Clicking on each question takes you to the page for that question where you can add your answer.
Controllers:
HomeController: should contain at least the following controller methods
- Index: displays list of top 10 questions
- About displays the About page
- Contact displays the Contact page
- Categories should display the top 10 categories
- Questions should display the top 10 questions

- QuestionController
- InsertQuestion(Question q);
- GetQuestions();
- GetQuestionByQuestionID(int QuestionID)
- AddAnswer(): Pass the necessary parameter(s)

Models
You will need the following models:
- Question which contains:
    - Question Id
    - QuestionName
    - QuestionDateAndTime { get; set; }
    - Category Id
    - Category object reference
- Category
    - Category Id
    - Category Name
- Answer
    - Answer Id
    - Question Id
    - Answer Text
    - Answer date and time
   
Database
In order to support your application, you will need to have a database behind it.
Your database will contain at least the following tables
- Categories
- Questions:
- Answers
