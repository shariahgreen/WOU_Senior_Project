1. User accounts and data must be stored indefinitely.  They don't want to delete; rather, mark items as "deleted" but don't actually delete them.  They also used the word "inactive" as a synonym for deleted.
2. Passwords should not expire
3. Site should never return debug error pages.  Web server should have a custom 404 page that is cute or funny and has a link to the main index page.
4. All server errors must be logged so we can investigate what is going on in a page accessible only to Admins.
5. English will be the default language.

## Identify Functional Requirements (User Stories)

E: Epic  
U: User Story  
T: Task  

1. [U] As a visitor to the site I would like to see a fantastic and modern homepage that introduces me to the site and the features currently available.
   1. [T] Create starter ASP dot NET MVC 5 Web Application with Individual User Accounts and no unit test project
   2. [T] Choose CSS library (Bootstrap 3, 4, or ?) and use it for all pages
   3. [T] Create nice homepage: write initial content, customize navbar, hide links to login/register
   4. [T] Create SQL Server database on Azure and configure web app to use it. Hide credentials.
2. [U] As a visitor to the site I would like to be able to register an account so I will be able to access athlete statistics
   1. [T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP script
   2. [T] Configure web app to use our db with Identity tables in it
   3. [T] Create a user table and customize user pages to display additional data
   4. [T] Re-enable login/register links
   5. [T] Manually test register and login; user should easily be able to see that they are logged in
3. [E] As an administrator I want to be able to upload a spreadsheet of results so that new data can be added to our system
4. [U] As a visitor I want to be able to search for an athlete and then view their athlete page so I can find out more information about them
5. [U] As a visitor I want to be able to view race results for an athlete so I can see how they have performed
6. [U] As a visitor I want to be able to view PR's (personal records) for an athlete so I can see their best performances
7. [E] 
    1. [U]
        1. [T]
        2. [T]
        3. [T]
    2. [U]
8. [U] As a robot I would like to be prevented from creating an account on your website so I don't ask millions of my friends to join your website and try to add comments about male enhancement drugs.
7. 
