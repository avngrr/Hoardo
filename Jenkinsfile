pipeline {
    agent any
    environment {
        PROJECT_ID = 'PROJECT-ID'
        CLUSTER_NAME = 'CLUSTER-NAME'
        LOCATION = 'CLUSTER-LOCATION'
        CREDENTIALS_ID = 'gke'
    }
    stages {
        stage("Checkout code") {
            steps {
                checkout scm
            }
        }
        stage("Build image") {
            steps {
                script {
                    myapp = docker.build("avngr/hoardo:${env.BUILD_ID}", "./src/Server")
                }
            }
        }
        stage("Push image") {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com', 'dockerhub') {
                            myapp.push("latest")
                            myapp.push("${env.BUILD_ID}")
                    }
                }
            }
        }        

                  podTemplate(inheritFrom: 'default')
                  {
                        node(POD_LABEL){
                            stage('List Configmaps') {
                                withKubeConfig([namespace: "hoardo"]) {
                                  sh 'kubectl get configmap'
                                  sh 'kubectl apply -f ./src/Server/api-deploy.yml'
                                }
                            }
                        }
                  }
            
        }
    }    
}