NAME="deepdivecicddeploy"
RG_NAME="deepdivedayonelinux"
LOCATION="eastus"

az group create -l $LOCATION -n $RG_NAME

az appservice plan create -n $NAME -g $RG_NAME --sku S1 --location $LOCATION --is-linux
az webapp create -g $RG_NAME -p $NAME -n $NAME -i "nginx"

az acr create --resource-group $RG_NAME --name deepdiveweekcontainer --sku Basic
az acr update -n deepdiveweekcontainer --admin-enabled true
acr="deepdiveweekcontainer.azurecr.io"
acrName="deepdiveweekcontainer"
acrUrl="https://$acr"
password=$(az acr credential show \
    --resource-group $RG_NAME \
    --name $acrName \
    --query "passwords[0].value")

az webapp config container set --name $NAME \
    --resource-group $RG_NAME \
    --docker-registry-server-url $acrUrl \
    --docker-registry-server-user $acrName \
    --docker-registry-server-password $password 