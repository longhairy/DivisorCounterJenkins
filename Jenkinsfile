pipeline{
	agent any
	triggers{
		pollSCM("* * * * *")
	}
	stages{
		stage('Build'){
			steps{
				sh 'docker compose build'
			}
		}
		stage("Prepare services"){
			steps{
				sh 'docker compose up counter-service'
			}
		}
		stage("Test"){
			steps{
				sh 'docker compose up test-service'
			}
		}
		stage("test cleanup"){
			steps{
				sh 'docker compose down'
			}
			
		}
		
		stage("Deliver"){
			steps{
				withCredentials([usernamePassword(credentialsId: 'DockerHub' , usernameVariable: 'USERNAME', passwordVariable:'PASSWORD')]){
					sh 'docker login -u $USERNAME -p $PASSWORD'
					sh 'docker image list'
					
					sh 'docker tag divisorcounterjenkins-counter-service longhairy/divisor_counter_jenkins:counter-service'
					sh 'docker push longhairy/divisor_counter_jenkins:counter-service'

					sh 'docker tag divisorcounterjenkins-cache-service longhairy/divisor_counter_jenkins:cache-service'
					sh 'docker push longhairy/divisor_counter_jenkins:cache-service'

					sh 'docker tag divisorcounterjenkins-test-service longhairy/divisor_counter_jenkins:test-service'
					sh 'docker push longhairy/divisor_counter_jenkins:test-service'

					
				}
			}
		}
		stage("Deploy"){
			steps{
				sh 'docker compose up -d'
			}
			
		}
		
	}
}