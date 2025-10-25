# GD2-Bres-Quentin-Unity_Roll_A_Ball2D

18/10 : Logique trouvé assez rapidement, inspiration du système de tir à l'arc en 2d sur unity,
Difficulté sur le addforce alors qu'il me fallait juste le ForceMode2D et aussi perte de temps sur le sytème d'appuie de souris alors que simple erreur d'un =+ au lieu de += ainsi que sur le GetMouseButton(1)) au lieu de GetMouseButtonUp(0))

25/10 : 
objectif : faire un grappin
Installation du package cinemachine afin de suivre mon joueur. dans window -> package Manager -> unity registry -> Cinemachine.
Joueur traverse le sol quand utilise le grappin, recherche de solution...
Soluce : mettre un layer, le joueur ne peut plus grab le sol.
même pb : le joueur peut traverser les murs ducoup... Recherche de vrai solution...
alors, juste une ***insérer mot vulgaire*** d'option sur le distance join 2D a cocher, le enable collision sur true. 1h30 de perdu. 
