#ifndef BYTE
	#define BYTE  unsigned char
#endif

#ifdef __cplusplus
	#define FAMATE_API __declspec(dllexport)
extern "C" { 
#else
	#define FAMATE_API 
#endif

	#define MAX_KEY_SIZE	     32
	#define KEY				     "Miracom.Famate.EES"

	typedef struct {
        BYTE key[MAX_KEY_SIZE]; 
        BYTE enckey[MAX_KEY_SIZE]; 
        BYTE deckey[MAX_KEY_SIZE];
    } CONTEXT; 

	FAMATE_API BYTE * _encrypt(BYTE *);
    FAMATE_API BYTE * _decrypt(BYTE *);
    FAMATE_API BYTE * _encrypt_key(BYTE *, BYTE *);
    FAMATE_API BYTE * _decrypt_key(BYTE *, BYTE *);

#ifdef __cplusplus
}
#endif
