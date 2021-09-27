# EDMI Test


    The application has been developed with .NET CORE 3.1, Angular 12 and MongoDB. The Backend has been separated from the FrontEnd and a no-sql database has been used in the Cloud.
    
   ![Alt text](/Images/App.png?raw=true "App")

    Deployed link: 
    https://edmi-app.herokuapp.com/



    Database:

    MongoDB Atlas has been used in the cloud. In order to create a database in the cloud it is necessary to register on the web, create a database and configure it.
    
   ![Alt text](/Images/MongoDB.png?raw=true "MongoDB")

    Backend:

    A REST API has been built with .NET CORE. It has been deployed with Azure from visual studio. An app and a group of apps have been created.

    Deployment link: 
    https://edmiapi.azurewebsites.net/

   ![Alt text](/Images/Azure.png?raw=true "Azure")

    FrontEnd: 

    A project has been built with Angular 12 and it has been deployed in Heroku making the following changes.

    Local deployment:

        FrontEnd: 
        commands:
        "npm install" to have all the libraries on local.
        "ng serve" to deploy on local.

    Heroku Deployment:
    
    Step 1: Ensure you have the latest version of angular CLI and angular compiler cli:

        npm install @angular/cli@latest @angular/compiler-cli --save-dev
    
    Step 2: Copy below dependencies from devDependencies to dependencies:

        "@angular/cli": "^11.0.2",
        "@angular/compiler-cli": "^10.0.14",
        "typescript": "~3.9.5"
        
    Step 3: Create heroku-postbuild script in package.json. Under “scripts”, add a “heroku-postbuild” command like so:

        "heroku-postbuild": "ng build --prod"
    
    Step 4: Add Node and NPM engines

          "engines": {
            "node": "12.18.2",
            "npm": "6.14.5"
          }
      
    Step 5: Install Server to run your app

        npm install express path --save
    Step 6: Create a server.js file in the root of the application and paste the following code.

        //Install express server
        const express = require('express');
        const path = require('path');

        const app = express();

        // Serve only the static files form the dist directory
        app.use(express.static('./dist/Edmi-FrontEnd'));

        app.get('/*', (req, res) =>
            res.sendFile('index.html', {root: 'dist/Edmi-FrontEnd/'}),
        );

        // Start the app by listening on the default Heroku port
        app.listen(process.env.PORT || 8080);
        Step 7: Change start command In package.json, change the “start” command to node server.js so it becomes:

        "start": "node server.js"
    Step 8: Host source code of Angular App on GitHub.
    Step 9: Login to Heroku and create a new app in Heroku.
    Step 10: Connecting GitHub repository to Heroku app.
