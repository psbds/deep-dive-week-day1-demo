NAME="deepdivecicddeploy"
RG_NAME="deepdivedayonelinux"
LOCATION="eastus"

az group create -l $LOCATION -n $RG_NAME

az appservice plan create -n $NAME -g $RG_NAME --sku S1 --location $LOCATION --is-linux
az webapp create -g $RG_NAME -p $NAME -n $NAME -i "nginx"
