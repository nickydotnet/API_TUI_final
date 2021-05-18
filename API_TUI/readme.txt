Procédure de déploiement:
On pourrait utiliser l'agent de build pour automatiser le déploiement et la compilation mais dans ce cas précis il aurait fallu un IIS configuré avec son agent de déploiement et un Build (XAML) sur le serveur TFS
UAT:

Lancez la solution et éxecutez la commande dans la console gestionnaire de package
PM> $env:ASPNETCORE_ENVIRONMENT='DEVELOPMENT'
PM> update-database

Créez un utilisateur applicatif au sein de votre organisation de type "ORGANISATION\usr_test_tui" et ajoutez dans le server SQL cet utilisateur ainsi que les droits INSERT,UPDATE,READ,DELETE sur la table ProductItems

SQL:
USE DatabaseTest
GRANT SELECT,UPDATE,INSERT,DELETE ON dbo.ProductItems TO "ORGANISATION\usr_test_tui";

Sur votre serveur IIS de UAT, déployez la solution "debug" en vérifiant que le nom du serveur SQL CoreContextConnection dans le fichier appsettings.Development.json.
Le pool applicatif doit être configuré avec l'utilisateur "ORGANISATION\usr_test_tui"


PROD:

Lancez la solution et éxecutez la commande dans la console gestionnaire de package
PM> $env:ASPNETCORE_ENVIRONMENT='PRODUCTION'
PM> update-database

Créez un utilisateur applicatif au sein de votre organisation de type "ORGANISATION\usr_prod_tui" et ajoutez dans le server SQL cet utilisateur ainsi que les droits INSERT,UPDATE,READ,DELETE sur la table ProductItems

SQL :
USE DatabaseProd
GRANT SELECT,UPDATE,INSERT,DELETE ON dbo.ProductItems TO "ORGANISATION\usr_prod_tui";

Sur votre serveur IIS de Prod, déployez la solution "Release",en vérifiant que le nom du serveur SQL CoreContextConnection dans le fichier web.config appsettings.json.
Le pool applicatif doit être configuré avec l'utilisateur "ORGANISATION\usr_prod_tui"


