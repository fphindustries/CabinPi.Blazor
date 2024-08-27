dotnet publish /p:PublishProfile=Properties/PublishProfiles/LocalPublish.pubxml
sudo systemctl stop cabinpi-blazor.service
cp -r  bin/Release/net8.0/linux-arm64/publish/* /opt/cabinpi-blazor/
sudo systemctl start cabinpi-blazor.service
sudo systemctl status cabinpi-blazor.service
