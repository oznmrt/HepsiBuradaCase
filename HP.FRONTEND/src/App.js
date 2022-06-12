import React from "react";
import { AppContextProvider } from "./contextapi/AppContext";
import MainPage from "./pages/mainpage/MainPage";

const loading = (
  <div className="pt-3 text-center">
    <div className="sk-spinner sk-spinner-pulse"></div>
  </div>
)

function App() {
  return (
    <React.Suspense fallback={loading}>
      <AppContextProvider>
        <div className="app">
          <MainPage />
        </div>
      </AppContextProvider>
    </React.Suspense>
  );
}

export default App;
