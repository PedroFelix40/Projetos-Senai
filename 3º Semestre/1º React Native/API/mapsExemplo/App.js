import { StatusBar } from 'expo-status-bar';
import { ActivityIndicator, StyleSheet, Text, View } from 'react-native';

// Import do maps
import MapView, { Marker, PROVIDER_GOOGLE } from 'react-native-maps'

// Expo location - Para pegar a posição atual do usuário
import {
  requestForegroundPermissionsAsync, // Solicito a permissão de loc
  getCurrentPositionAsync, // Captura a localização

  watchPositionAsync, // captura em tempo real a localizacao
  LocationAccuracy // Precisao da captura
} from 'expo-location'

import { useEffect, useState, useRef } from 'react';

import MapViewDirections from 'react-native-maps-directions';


// api
import { mapskey } from './Utils/mapsKey';

export default function App() {
  const mapRefence = useRef(null)
  const [initialPosition, setInitialPosition] = useState(null);
  const [finalPosition, setFinalPosition] = useState(
    {
      latitude: -23.60000,
      longitude: -46.7187,
    }
  )

  async function CapturarLocalizacao() {
    const { granted } = await requestForegroundPermissionsAsync();

    if (granted) {
      const currentPosition = await getCurrentPositionAsync()

      setInitialPosition(currentPosition)

      console.log(initialPosition)
    }
  }

  async function RecarregarVizualicaoMapa() {
    if (mapRefence.current && initialPosition) {
      
        await mapRefence.current.fitToCoordinates(
          [
            { latitude: initialPosition.coords.latitude, longitude: initialPosition.coords.longitude },
            { latitude: finalPosition.latitude, longitude: finalPosition.longitude }
          ],
          { 
            edgePadding: { top: 100, right: 100, bottom: 100, left: 100 },
            animated: true
          }
        ) 
      
    }
  }

  useEffect(() => {
    CapturarLocalizacao()

    // capturar localizacao
    watchPositionAsync({
      accuracy : LocationAccuracy.High,
      timeInterval : 1000,
      distanceInterval : 1
    }, async(response) => {
      await setInitialPosition( response )

      mapRefence.current?.animateCamera({
        pitch : 60, 
        center : response.coords
      })
    }
    
    )
  }, [10000000])

  useEffect(() => {
    RecarregarVizualicaoMapa()
  }, [initialPosition])

  return (
    <View style={styles.container}>
      {
        initialPosition != null
          ? (

            <MapView
              ref={mapRefence}
              initialRegion={{
                latitude: initialPosition.coords.latitude,
                longitude: initialPosition.coords.longitude,
                latitudeDelta: 0.005,
                longitudeDelta: 0.005
              }}
              provider={PROVIDER_GOOGLE}
              style={styles.map}
              customMapStyle={grayMapStyle}
            >
              <MapViewDirections
                origin={initialPosition.coords}
                destination={{
                  latitude: finalPosition.latitude,
                  longitude: finalPosition.longitude,
                  latitudeDelta: 0.005,
                  longitudeDelta: 0.005
                }}

                apikey={mapskey}

                strokeWidth={5}
                strokeColor='#496BBA'
              />

              {/* Criando um marcador no mapa */}
              <Marker
                coordinate={{
                  latitude: initialPosition.coords.latitude,
                  longitude: initialPosition.coords.longitude,
                }}
                title='Localização atual'
                description='Qualquer lugar do map'
                pinColor='red'
              />

              <Marker
                coordinate={{
                  latitude: finalPosition.latitude,
                  longitude: finalPosition.longitude,
                }}
                title='Localização atual'
                description='Qualquer lugar do map'
                pinColor='blue'
              />
            </MapView>
          ) : (
            <>
              <Text>Localização não encontrada</Text>

              <ActivityIndicator />
            </>
          )
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

  map: {
    flex: 1,
    width: '100%'
  }
});

const grayMapStyle = [
  {
    elementType: "geometry",
    stylers: [
      {
        color: "#E1E0E7",
      },
    ],
  },
  {
    elementType: "geometry.fill",
    stylers: [
      {
        saturation: -5,
      },
      {
        lightness: -5,
      },
    ],
  },
  {
    elementType: "labels.icon",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#FBFBFB",
      },
    ],
  },
  {
    elementType: "labels.text.stroke",
    stylers: [
      {
        color: "#33303E",
      },
    ],
  },
  {
    featureType: "administrative",
    elementType: "geometry",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "administrative.country",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "administrative.land_parcel",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "administrative.locality",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi.business",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "geometry",
    stylers: [
      {
        color: "#66DA9F",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.stroke",
    stylers: [
      {
        color: "#1B1B1B",
      },
    ],
  },
  {
    featureType: "road",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "road",
    elementType: "geometry.fill",
    stylers: [
      {
        color: "#C6C5CE",
      },
    ],
  },
  {
    featureType: "road",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#FBFBFB",
      },
    ],
  },
  {
    featureType: "road.arterial",
    elementType: "geometry",
    stylers: [
      {
        color: "#ACABB7",
      },
    ],
  },
  {
    featureType: "road.highway",
    elementType: "geometry",
    stylers: [
      {
        color: "#8C8A97",
      },
    ],
  },
  {
    featureType: "road.highway.controlled_access",
    elementType: "geometry",
    stylers: [
      {
        color: "#8C8A97",
      },
    ],
  },
  {
    featureType: "road.local",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "transit",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "water",
    elementType: "geometry",
    stylers: [
      {
        color: "#8EA5D9",
      },
    ],
  },
  {
    featureType: "water",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
];


