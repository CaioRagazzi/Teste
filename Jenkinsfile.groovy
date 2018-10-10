pipeline {
    agent any
    }
    stages {
        stage ('Restore Packages') { 
            steps {
                bat "dotnet restore"
            }
        }
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
