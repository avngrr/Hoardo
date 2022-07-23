podTemplate(inheritFrom: 'default',
containers: [containerTemplate(image: 'docker', name: 'docker', command: 'cat', ttyEnabled: true)],
volumes: [
    hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')
  ])
{
    node(POD_LABEL)
    {
            stage("Checkout code") 
            {
                    checkout scm
               
            }
            stage("Build image") 
            {
                container('docker')
                {
                    script 
                    {
                        myapp = docker.build("avngr/hoardo:${env.BUILD_ID}", "./src/Server")
                        docker.withRegistry('https://registry.hub.docker.com', 'dockerhub') 
                        {
                                myapp.push("latest")
                                myapp.push("${env.BUILD_ID}")
                        }
                    }
                }
            }             
            stage('push to kubernetes cluster') 
            {
                withKubeConfig([namespace: "hoardo"]) 
                {
                    sh 'kubectl apply -f ./src/Server/api-deploy.yml'
                }
            }
        
    }  
}    