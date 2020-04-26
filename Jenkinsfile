pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'dotnet restore NetKnowledgeTest.csproj'
        sh 'dotnet clean NetKnowledgeTest.csproj'
        sh 'dotnet build NetKnowledgeTest.csproj --configuration Release'
      }
    }

    stage('Publish') {
      steps {
        sh 'docker build -t ${BUILD_NAME}:latest -f Dockerfile .'
      }
    }

  }
  environment {
    BUILD_NAME = 'netknowladgetest'
    BUILD_PATH = './bin/Release'
    PUBLISH_PATH = './bin/Publish'
  }
}