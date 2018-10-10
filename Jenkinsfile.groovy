pipeline {
    agent any

    stages {
        stage('Restore') {
            steps {
                echo 'Restoring..'
                bat "dotnet clean"
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
