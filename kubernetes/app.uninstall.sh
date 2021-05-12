kubectl delete -f bank.auth.deployment.yml
kubectl delete -f bank.loans.deployment.yml
kubectl delete -f bank.apigateway.deployment.yml

kubectl delete -f bank.auth.service.yml
kubectl delete -f bank.loans.service.yml
kubectl delete -f ingress.service.yml