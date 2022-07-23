podTemplate(inheritFrom: 'default')
{
    node(POD_LABEL)
    {
            stage("Checkout code") 
            {
                    checkout scm
               
            }
            stage("Build image") 
            {

                    script 
                    {
                        myapp = docker.build("avngr/hoardo:${env.BUILD_ID}", "./src/Server")
                    }
                
            }
            stage("Push image") 
            {

                    script 
                    {
                        docker.withRegistry('https://registry.hub.docker.com', 'dockerhub') 
                        {
                                myapp.push("latest")
                                myapp.push("${env.BUILD_ID}")
                        }
                    }
                
            }        

        
            stage('List Configmaps') 
            {
                withKubeConfig([namespace: "hoardo"]) 
                {
                    sh 'kubectl apply -f ./src/Server/api-deploy.yml'
                }
            }
        
    }  
}    