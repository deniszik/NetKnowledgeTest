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

  }
}