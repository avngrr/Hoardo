podTemplate(
  serviceAccountName: 'jenkins-robot',
  containers: [
    containerTemplate(
      name: 'docker',
      image: 'docker',
      command: 'cat',
      ttyEnabled: true)],
  volumes: [
    hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock'),
    hostPathVolume(hostPath: '/usr/bin/kubectl', mountPath: '/usr/bin/kubectl')]
)
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
                        registryCredential = 'dockerhub' 
                        myapp = docker.build("avngr/hoardo:${env.BUILD_ID}")
                        docker.withRegistry('', registryCredential) 
                        {
                                myapp.push("latest")
                                myapp.push("${env.BUILD_ID}")
                        }
                    }
                }
            }             
            stage('push to kubernetes cluster') 
            {
                withKubeConfig([credentialsId: 'ServiceAccount', namespace: "jenkins"]) 
                {
                    sh 'kubectl apply -f ./src/Server/api-deploy.yml'
                }
            }
        
    }  
}    