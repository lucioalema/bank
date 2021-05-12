kubectl apply -f bank.auth.deployment.yml
kubectl apply -f bank.loans.deployment.yml
kubectl apply -f bank.apigateway.deployment.yml

kubectl apply -f bank.auth.service.yml
kubectl apply -f bank.loans.service.yml
kubectl apply -f ingress.service.yml