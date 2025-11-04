# GD2-Bres-Quentin-Unity_Roll_A_Ball2D

***Intro***
Ce projet est un prototype de jeu d'arcade en 2D ou le joueur incarne une boule qui doit collecter des objets pour marquer des points.
Le jeu comporte des plusieurs niveaux, le joueur se déplace grâce à deux mécanique de déplacement : le grapin et la propulsion.

Le niveau tuto est bien finit, les deux autres sont juste la visilibilité de la scène ou j'ai travailler et le niveau 3, une démo d'un tourelle que je n'ai pas réussi a faire fonctionner comme je le voulais.

***Fonctionnalités principale :***
déplacement fluide de la balle
système de score lié aux collectibles
Plusieurs niveaux
Apparition conditionnelle d'objet
Menu de base
Sound design de base
Condition de victoire (aller au bout du niveau) et défaite (retour au dernier checkpoint si échec)

***Bonus : ***
Nouveau système de déplacement : saut/grappin
Nouveau type de collectible : Levier pour faire apparaitre pièce et rettirer des pièges
piège morte : chute dans le vide/pique
Sound design contextuel : Bruit checkpoint, mort dans le vide, mort sur une pique, niveau de propulsion, rammasage pièce, bruit levier
Menu de setting : réglage du volume général, fullscreen, résolution

***LD : ***
Le niveau tuto a été conçu avec une difficulté croissante, le jeu reste difficile de base, quelques décorations ont été placé ainsi qu'un background simplifié.

***Sound design : ***
gestion centralisée via le script SoundFXManager, facilement modulable.
Réglage du volume possible (si je le retravaille).

***Difficulté rencontrées/solution :***

Problème rencontré sur la propulsion du saut, je n'utilisais tout simplement pas un ForceMode2D.
Problème : Le joueur traverser les murs. Soluce mettre le enable Collision du distance Joint 2D sur true
Problème rencontré sur les collisions, tout simplement parce que c'était une collider et pas un collider2D, j'ai vraiment perdu du temps
Problème : Des lignes vertes apparaissaient quand le joueur se déplacé. Solution : désactivé le HDR et le MSAA, solution trouvé sur internet je ne comprend toujours pas pourquoi.
Problème : Couleur du sprite ne changeait pas. Soluce : J'ai vu que unity appliquer bien la couleur, mais mon sprité était noir de base, alors j'ai modifier la texture de base et je l'ai réimporter
Problème : Le grappin traverser les murs. Soluce : Ajout d'une condition de distance entre la balle et la souris AVANT de l'activer.
Problème : Le son sonnait différament en jeu. Soluce : Def spatialBlend = 0f;
Problème : Son se jouait en boucle. Soluce : rajouter encore des conditions avec un tableau de bool.
Problème : Tourelle redéclencher coroutine plusieurs fois, résultat une véritable mitralliette. Soluce : Tout simplement vérifier si la courinte n'est pas lancé donc pas null.
Problème : Angle Tourelle,  fuyant le joueur. Solution : Inverser la tourelle. Autre : Angle correct que d'un coté, ajout d'une correction d'angle que du coté qui marche.
Problème : Projectile plus rapide si le joueur est plus loin de la tourelle. Soluce : Normaliser la direction et après multiplier cette direction normalisé par la vitesse.
Abondon de l'utilisation de la tourelle dans un niveau.


***Platest***
J'ai organiser des playtests et j'ai pas mal de retour ainsi que des bugs ( grappin traverser les murs, bug de col...)
voici un exemple de retour : 

je vais te dire tout ce qui va pas ou qui serait cool a ajouter:

-pouvoir se déplacer dans le menu ou mettre un peu des effets

-quand on rentre dans le jeu, on voit pas toute l'explication des controles, d'ailleurs je pense qu'elles pourraietn être plus compacte

2: ce serait cool un indicateur de puissance quand on "charge" mais j'imagine que c'est chiant a faire genre les flèches elles deviennent rouge une par une.un indicateur qui montre qu'on est en train de charger, enre un effet visuel, un changement de couleur ou autre

1: je peux pas mettre pause avec échap

je sais pas si c'est ton jeu ou mon pc mais parois j'ai des sortes de ligne verte au milieu de l'écran mais ça ne me le fait pas sur d'autres jeu, après c'est pas perturbant mais voila

quand on tombe on voit la fin des piliers genre la fin de la chute c'est vide
 
c'est un petit peu long a charger en puissance je trouve
la puissance minimale est trop petite a mon gout
il manque des effets visuels mais ça a l'air très chiant a faire
je suis mort avec de la vitesse et j'ai gardé la vélocité au point de réaparition, je pense que l'écran de mort pourrait régler ça pcque ça permettrait au sprite de tout reset

ici on voit pas le plafond ce qui rend la visée un peu dur, c'est peut être un choix mais je préfère te le dire

si on clique trop haut sur le mur ça grab pas donc j'imagine que le grab est codé sur les murs mais je pense que c'est un mauvais choix pcque du coup si t'as oublié des murs, t'es cook et si tu rates aussi. après ça peut rajouter de la compléxité au jeu mais il faudrait le préciser dans les controles je pense
 
les plateformes couleur bronze elles rappellent des plaques de cuivre, je pense que c'est fait exprès mais du coup je pense que ce serait intéressant de mettre un petit bonhome plutot qu'une boule même si je pense que c'est le cadet de tes soucis
 
j'ai oublié de screen mais en dessous de l'arbre ya des textures pas rempli
 
-diversifier les textures

la musique de fond est bien mais au bout de 10min c'est chiant pour être honnête, ce srait cool d'en vaoir une différente pour le niv 2 et que la mélodie soit un peu plus longue




***Conclusion : ***
J'ai beaucoup appris sur ce projet.Beaucoup de "perte" de temps à trouver la petite ligne de code ou case à cocher dans l'inspecteur qui résout les problèmes. 
Je me rend compte que j'ai passer beaucoup de temps sur les conditions. 
J'ai passer beaucoup de temps sur le grappin, beaucoup de problème pour le rendre "smooth".
Je suis vachement plus à l'aise avec le code, je n'ai absolument pas galérer pour par exemple le levier.
Compilation découverte : 
Tile map, tile pallette, Cinemachine, Mixer, Group mix, Animator, Animation, distance join 2D, LineRenderer
Code : Tableau de bool, AddForce, ForceMode2D, instance, Invoke , les ||,&& et !variable, Physics2D.OverlapCircle, ClosePoint, SetPosition, void Awake, AudioSource.

