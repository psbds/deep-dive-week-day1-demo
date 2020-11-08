NAME="deepdivevisualstudiodeploy"
RG_NAME="deepdivedayone"
LOCATION="eastus"

az group create -l $LOCATION -n $RG_NAME

az appservice plan create -n $NAME -g $RG_NAME --sku S1 --location $LOCATION
# az appservice plan create -n $NAME -g $RG_NAME --sku S1 --location $LOCATION --hyper-v
# az appservice plan create -n $NAME -g $RG_NAME --sku S1 --location $LOCATION --is-linux

# az webapp list-runtimes
az webapp create -g $RG_NAME -p $NAME -n $NAME -r "aspnet|V4.8"
# az webapp create -g $RG_NAME -p $NAME -n $NAME -r "node|10.6"
# az webapp create -g $RG_NAME -p $NAME -n $NAME -i "nginx"
