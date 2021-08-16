 # RPGShop ⚔
RPGShop é um projeto de padrão  [RestAPI](https://www.redhat.com/pt-br/topics/api/what-is-a-rest-api)  para portfólio criado por  [Erik Bergkamp](https://github.com/eriking50). 

## Sobre
O projeto tem como base Asp Net 5 há 2 opções de banco de dados disponíveis, uma é o [MongoDB](https://www.mongodb.com/pt-br)(Foi utilizado o Docker para criação de uma imagem Mongo) e outra que apenas utiliza a memória durante execução para poder ter o dados (Notar que ao fechar o programa os dados são perdidos).

## Instruções
Para rodar o programa é necessário apenas buildar o app, atualmente a opção de banco de dados selecionada é a do MongoDB, caso queira trocar, apenas troque na linha 41 no arquivo Startup.cs:

#### Memória
	services.AddSingleton<IItemsRepository,  InMemItemsRepository>();

#### MongoDB
	services.AddSingleton<IItemsRepository,  MongoDbItemsRepository>();