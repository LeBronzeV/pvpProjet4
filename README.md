# pvpProjet4
un projet pvp MOBA en C#

fonctionnement:
	Deux joueurs, ayant les m�me capacit�es, s'affronte dans une ar�ne.
	le but est de d�truire la base enemi grace � ses comp�tence et ses sbires.
	les sbires sont des IA qui parcour la map pour d�truire la base adverse.
	le joueur poss�de 3 attaques:
		-un dash( clic droit de la sourie ou encore un bouton de la manette.)
		-une boule de feu (clic gauche de la sourie ou encore un autre bouton de la manette)
		-un sort de zone ou grenade (barre espace ou un troisi�me bouton de la manette)
	il se d�place avec zqsd ou le joystic de la manette( pour l'instant le joueur 2 se d�place avec oklm)
	la partie se termine quand l'un des deux a d�truit le cristal adverse.

bug non r�solu:
	-probl�me de fps qui Drop.
	-les barre de vie (elle ne s'oriente pas en fonction de la cam�ra).
	-respawn(le personnage tremble pendant quelque instant).
	
difficult�es rencontr�es
	-manipulation des IA (raycast pour attasquer).

bug r�solu
	-pas de bug r�solu sans comprendre pourquoi.

liste des asset
	faite:
		-map(arbre non compris
		-menu
		-particule(texture non comprise)
		-barre de vie
 	recup:
		-texture
		-arbre
		-sbire 
		-anim sbire