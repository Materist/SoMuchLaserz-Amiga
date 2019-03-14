Global BUTFIRE
Global MAKS
MAKS=0

SPLASHSCREEN

Rem *****Do przejscie do instrukcji jak grac*****  

Procedure LDSCR
   Load "AMOS_BANK:AMOS_Music/Music_Bumioh.ABK",15
   Load Iff "asm:GrafikiLaserz/LOADING.PIC",5
   Bank Swap 3,15
   Music 1
   Repeat 
      CHECKFIRE
      BUTFIRE=Param
   Until BUTFIRE=1
   Erase All 
End Proc

Rem ************************************** 

Rem *****Do zrobienia procedura wyswietlajaca wskazowki dot. gry*****  

Procedure TUTORIALSCR
End Proc

Rem ***************************************

Procedure CHECKFIRE
   If Fire(1)
      BUTFIRE=1
   Else 
      BUTFIRE=0
   End If 
End Proc[BUTFIRE]


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

   Ink KOL,7
