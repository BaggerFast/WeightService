﻿window.goBackIfNotHomePage = function() {
  if (window.history.length === 2)
    return false;
  if (window.history.length > 2) {
    window.history.back();
    return true;
  }
  return false;
}