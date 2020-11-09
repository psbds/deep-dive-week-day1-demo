NAME="deepdiveweekapimanagement"
RG_NAME="deepdiveweekapimanagement"
LOCATION="eastus"

az group create -l $LOCATION -n $RG_NAME

az appservice plan create -n $NAME -g $RG_NAME --sku S1 --location $LOCATION
az webapp create -p $NAME -n $NAME -g $RG_NAME 