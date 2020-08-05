
export function formatErrorResponse(errorResponse: any): string {
    let message = '';
    if (errorResponse.error.errors){
     message = errorResponse.error.errors[Object.keys(errorResponse.error.errors)[0]];
    }else{
      message = errorResponse.error.messages[0];
    }
    return message;
  }
