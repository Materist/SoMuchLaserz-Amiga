Global BUTFIRE
Global MAKS
Global PX
Global PY
PX=200
PY=200
Global PS
MAKS=0

SPLASHSCREEN

Rem *****LOAD SCREEN*****  
Rem CHC - ID of stage

Procedure LDSCR[CHC]
   Load "AMOS_BANK:AMOS_Music/Music_Bumioh.ABK",15
   Load Iff "asm:GrafikiLaserz/LOADING.PIC",5
   Bank Swap 3,15
   Music 1
   Repeat 
      CHECKFIRE
      BUTFIRE=Param
   Until BUTFIRE=1
   BUTFIRE=0
   Erase All 
   If CHC=1
      TUTORIALSCR
   End If 
End Proc

Rem *****TUTORIAL SCREEN*****  

Procedure TUTORIALSCR
   Load Iff "asm:GrafikiLaserz/TUTORIAL.PIC",5
   Repeat 
      CHECKFIRE
      BUTFIRE=Param
   Until BUTFIRE=1
   Erase All 
End Proc

Rem *****CHECK FIRE PROCEDURE***** 

Procedure CHECKFIRE
   If Fire(1)
      BUTFIRE=1
   Else 
      BUTFIRE=0
   End If 
End Proc[BUTFIRE]

Rem *****DISPLAY TEXT WITH CHANGING COLORS*****

Procedure KOLTEXT[KOL,LOWKOL,HIGHKOL,X,Y,MSG$]

   If MAKS=0
      KOL=KOL+1
   Else 
      KOL=KOL-1
   End If 

   If KOL=HIGHKOL
      MAKS=1
   End If 

   If KOL=LOWKOL
      MAKS=0
   End If 

   Ink KOL,7,
   Text X,Y,MSG$

End Proc[KOL]

Rem ***** READING JOY AND CHANGE X/Y POSITION *****

Procedure MVPL

   If Jup(1)
      PY=PY-1
   End If 

   If Jdown(1)
      PY=PY+1
   End If 

   If Jright(1)
      PX=PX+2
   End If 

   If Jleft(1)
      PX=PX-2
   End If 

End Proc

Rem ***** DRAWING BOBS ***** 

Procedure DRB[NR,X,Y,STATE]

   Wait Vbl 
   If STATE>0
      Bob NR,X,Y,STATE
   Else 
      Bob NR,X,Y,
   End If 

End Proc

Rem ***** SET ANIMATION FOR BOBS ***** 

Procedure ANBOP
End Proc


Rem ***** MAIN LOOP *****

Procedure MLOOP

   MVPL
   DRB[1,PX,PY,0]

End Proc

Rem ***** SLASHSCREEN *****

Procedure SPLASHSCREEN
   BUTFIRE=0
   KOL=0
   Load Iff "asm:GrafikiLaserz/INTRO.PIC",5
   Load "asm:GrafikiLaserz/MegaMen/bobek",14
   Channel 1 To Bob 1
   DRB[1,200,200,1]
   Anim 1,"(1,60) (2,15)L"
   Anim On 
   Load "AMOS_BANK:AMOS_Music/Music_Draconus.ABK",3
   Music 1
   Repeat 
      CHECKFIRE
      BUTFIRE=Param
      KOLTEXT[KOL,0,16,80,150,"PRESS START BUTTON"]
      KOL=Param
      MLOOP
   Until BUTFIRE=1
   Erase All 
   BUTFIRE=0
   LDSCR[1]
End Proc


