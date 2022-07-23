
    podTemplate(inheritFrom: 'default')
        {
            node(POD_LABEL){
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

        
                stage('List Configmaps') {
                    withKubeConfig([namespace: "hoardo"]) {
                        sh 'kubectl get configmap'
                        sh 'kubectl apply -f ./src/Server/api-deploy.yml'
                    }
                }
            }
        }  
    }    
