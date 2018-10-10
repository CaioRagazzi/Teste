pipeline {
    agent any
    
    stage ('Restore Packages') { 
        steps {
            bat "dotnet restore"
              }
    }
    stages {
        stage('Build') {
            steps {
                echo 'Building 123..'
                bat "dotnet build --configuration Release"
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
