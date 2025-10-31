# GD2-Bres-Quentin-Unity_Roll_A_Ball2D


Ce projet est un prototype de jeu d'arcade en 2D ou le joueur incarne une boule qui doit collecter des objets pour marquer des points.
Le jeu comporte des plusieurs niveaux, le joueur se déplace grâce à deux mécanique de déplacement : le grapin et la propulsion.

Fonctionnalités principale :
déplacement fluide de la balle
système de score lié aux collectibles
Plusieurs niveaux
Apparition conditionnelle d'objet
Menu de base
Sound design de base
Condition de victoire (aller au bout du niveau) et défaite (retour au dernier checkpoint si échec)

Bonus : 
Nouveau système de déplacement : saut/grappin
Nouveau type de collectible : Levier pour faire apparaitre pièce et rettirer des pièges
piège morte : chute dans le vide/pique
Sound design contextuel : Bruit checkpoint, mort dans le vide, mort sur une pique, niveau de propulsion, rammasage pièce, bruit levier
Menu de setting : réglage du volume général, fullscreen, résolution

LD : 
Les niveaux ont été conçu avec une difficulté croissante, le jeu reste difficile de base, quelques décorations ont été placé ainsi qu'un background.

Sound design : 
gestion centralisée via le script SoundFXManager, facilement modulable.
Réglage du volume possible (si je le retravaille).

Difficulté rencontrées/solution :

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


Conclusion : 
J'ai beaucoup appris sur ce projet.Beaucoup de "perte" de temps à trouver la petite ligne de code ou case à cocher dans l'inspecteur qui résout les problèmes. 
Je me rend compte que j'ai passer beaucoup de temps sur les conditions. 
J'ai passer beaucoup de temps sur le grappin, beaucoup de problème pour le rendre "smooth".
Je suis vachement plus à l'aise avec le code, je n'ai absolument pas galérer pour par exemple le levier.
Compilation découverte : 
Tile map, tile pallette, Cinemachine, Mixer, Group mix, Animator, Animation, distance join 2D, LineRenderer
Code : Tableau de bool, AddForce, ForceMode2D, instance, Invoke , les ||,&& et !variable, Physics2D.OverlapCircle, ClosePoint, SetPosition, void Awake, AudioSource, 

