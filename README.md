# Parions

un mini-jeu de pari entre amis dans le cadre d’un salon interactif organisé à la Plaine Image de Tourcoing.



Mode d'emploie : 







A l'ouverture du Jeux, on a la possibilite sois de mener le jeu et de creer un serveur ou de rejoindre un serveur comme l'illustre l'image.



<img width="960" alt="MenuPrincipal" src="https://user-images.githubusercontent.com/116499135/210177531-ad8dda56-5fa8-4dcc-b4bf-ae21ce7b9ccf.png">

 
 
 
Le joueur qui lance le jeu fait office de serveur pour les autres et peut paramétrer le nombre de joueurs qui peuvent entrer dans la partie ainsi que le nombre de tours de jeux, Comme on le voit sur l'illustration.


La partie ne peut démarrer que lorsque tous les joueurs nécessaires ont rejoins la partie. Chaque joueur dispose de sa propre fenêtre comme on le voit sur la premiere image sur la gauche.



<img width="960" alt="CreerUnServeur_RejoindreLequipe" src="https://user-images.githubusercontent.com/116499135/210177541-20fa1299-672c-40a0-a4ed-5598b82eaf88.png">




A chaque tour de jeu, les joueurs reçoivent sur leur fenêtre de jeu la même question à laquelle ils doivent répondre par oui ou par non, puis doivent estimer le nombre de oui total des joueurs avant de valider ces réponses, Comme l'illustre la prochaine image.




<img width="960" alt="Question" src="https://user-images.githubusercontent.com/116499135/210177550-175f085d-a260-458a-af72-740e07d51d37.png">





Lorsque tous les joueurs ont donné leurs réponses, le nombre de oui est affiché sur chaque fenêtre.


les joueurs ayant bien estimé ce nombre gagnent 2 points. Si personne n’a bien estimé ce nombre, les joueurs les plus proches de ce nombre par score inférieur à ce nombre uniquement gagnent 1 point.




<img width="960" alt="NombreDeOui" src="https://user-images.githubusercontent.com/116499135/210177556-14d3cc85-b077-4c5e-9cea-27cea6cca7ee.png">





Lorsque le nombre de tours défini par le joueur qui a lancé la partie est terminé, Il s'affichera un tableau avec le score des participants, le gagnant est le joueur (ou les joueurs) ayant le plus de points.





<img width="960" alt="Score" src="https://user-images.githubusercontent.com/116499135/210177571-49a6f00b-5319-4c28-b078-0d0c711c57f6.png">









UML : Diagramme De Classe.








![DiagrammeDeClasseParions](https://user-images.githubusercontent.com/116499135/210181886-d69007e2-dfee-40f7-bada-29efa1ff6750.jpg)










design patterns utilisés  


MVVM(Model-view-viewmodel) est un modèle architectural qui facilite la séparation du développement de l’interface utilisateur graphique. 


Abstract factory pour encapsuler des familles d'objets liés qui ont un thème commun sans spécifier leurs classes concrètes.


Singleton pour restreindre l'instanciation d'une classe à un seul objet (ou à quelques objets seulement). 

Strategy pour permuter dynamiquement les algorithmes utilisés, les rendre interchangeables.



Mécanisme de synchronisation : Sockets permettent une communication point-to-point et bidirectionnelle entre deux processus.

