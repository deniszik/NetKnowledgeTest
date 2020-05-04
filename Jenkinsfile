pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'dotnet restore NetKnowledgeTest.csproj'
        sh 'dotnet clean NetKnowledgeTest.csproj -o ${BUILD_PATH}'
        sh 'dotnet build NetKnowledgeTest.csproj --configuration Release -o ${BUILD_PATH}'
      }
    }
    stage('Publish') {
      steps {
        sh 'dotnet publish NetKnowledgeTest.csproj --configuration Release -o ${PUBLISH_PATH}'
        sh 'docker build -t ${BUILD_NAME}:latest -f Dockerfile .'
      }
    }

  }
  environment {
    BUILD_NAME = 'netknowledgetest'
    BUILD_PATH = './bin/Release'
    PUBLISH_PATH = './bin/Publish'
  }
}