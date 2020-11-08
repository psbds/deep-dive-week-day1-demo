NAME="deepdiveclideploy"
RG_NAME="deepdivedayonelinux"

cd src
zip my-app.zip *
mv my-app.zip ../
cd ../

az webapp deployment source config-zip -g $RG_NAME -n $NAME --src my-app.zip