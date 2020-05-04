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
        sh 'docker build -t ${IMAGE_NAME} -f Dockerfile .'
        sh 'docker tag ${IMAGE_NAME} ${NEXUS_URL}/${IMAGE_NAME}'
      }
    }
    stage('Cleanup') {
      steps {
        sh 'docker image rm ${IMAGE_NAME} -f'
        sh 'docker image prune -f'
      }
    }
  }
  environment {
    BUILD_NAME = 'netknowledgetest'
    BUILD_PATH = './bin/Release'
    PUBLISH_PATH = './bin/Publish'
    IMAGE_NAME = 'netknowledgetest:latest'
    NEXUS_URL = 'nexus:10082'
  }
}