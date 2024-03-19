import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

// 1º
import * as LocalAuthentication from "expo-local-authentication"

// 2º
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useEffect, useState } from 'react';
import moment from 'moment';

export default function App() {

  // salvar objeto com histórico
  const [dateHistory, setDateHistory] = useState({})

  // Salvar o status autenticado
  const [authenticated, setAuthenticated] = useState(false)

  // salvar a referência de suporte a 
  const [isBiometricSupported, setIsBiometricSupported] = useState(false)

  // Verificar se existe biometria
  async function CheckExistAuthentication() {
    const compatible = await LocalAuthentication.hasHardwareAsync();

    // Salvar o status de compatibilidade com a biometria
    setIsBiometricSupported(compatible);
  }

  // salva histórico da ultima autenticação
  async function SetHistory() {
    const objAuth = {
      dataAuthentication: moment().format('DD/MM/YYYY HH:mm:ss')
    }

    await AsyncStorage.setItem('authenticate', JSON.stringify(objAuth))

    setDateHistory(objAuth)
  }

  //recebe ultima autenticação
  async function GetHistory() {
    const objAuth = await AsyncStorage.getItem('authenticate');

    if (objAuth) {
      setDateHistory(JSON.parse(objAuth))
    }
  }

  async function HandleAuthentication() {
    // Verificar se existe biometria cadastrada
    const biometricExist = await LocalAuthentication.isEnrolledAsync();

    // Validar existencia
    if (!biometricExist) {
      return Alert.alert(
        'Falha ao logar',
        'Não foi encontrada nenhuma biometria cadastrada.'
      )
    }

    // Caso exista 
    const auth = await LocalAuthentication.authenticateAsync()

    setAuthenticated(auth.success)

    // Verficar se está autenticado
    if (auth.success) {
      SetHistory();
    }
  }

  useEffect(() => {
    CheckExistAuthentication();

    GetHistory();
  }, [])

  return (
    <View style={styles.container}>
      <Text style={styles.title}>
        {
          isBiometricSupported
            ? 'Seu dispositivo é compativel com a biometra'
            : 'O seu seu dispositivo não suporta a biometria / face id'
        }
      </Text>

      <TouchableOpacity style={styles.bntAuth} onPress={() => HandleAuthentication()}>
        <Text style={styles.txtAuth}>
          Autenticar acesso
        </Text>
      </TouchableOpacity>

      <Text style={[styles.txtReturn, { color: authenticated ? 'green' : 'red' }]}>
        {
          authenticated
            ? 'Autenticado'
            : 'Nao autenticado'
        }
      </Text>

      {
        dateHistory.dataAuthentication
          ? <Text style={styles.txtHistory}>
            Último acesso em {dateHistory.dataAuthentication}
          </Text>
          : null
      }
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  title: {
    fontSize: 20,
    width: '70%',
    textAlign: 'center',
    lineHeight: 30
  },
  bntAuth: {
    padding: 16,
    borderRadius: 10,
    margin: 20,
    backgroundColor: '#ff8000'
  },
  txtAuth: {
    fontSize: 20,
    color: 'white',
    fontWeight: 'bold'
  },
  txtReturn: {
    fontSize: 22,
    marginTop: 50
  },
  txtHistory : {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#858383',
    position: 'absolute',
    bottom: 120
  }
});
